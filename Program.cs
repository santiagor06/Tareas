using api;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/api/tareas", async([FromServices] TareasContext dbContext) =>{
    
    return  Results.Ok(dbContext.Tareas.Include(p=>p.Categoria).Where(p=>p.Prioridad==Prioridad.Alta));
});
app.MapPost("/api/tareas", async([FromServices] TareasContext dbContext,[FromBody]Tarea tarea) =>{
    tarea.Fecha=DateTime.Now;
    tarea.TareaId=Guid.NewGuid();
    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return  Results.Created();
});
app.MapPut("/api/tareas/{id}", async([FromServices] TareasContext dbContext,[FromBody]Tarea tarea,[FromRoute]Guid id) =>{
  
    var tareaActual=dbContext.Tareas.Find(id);
    
    if(tareaActual !=null){
        tareaActual.Prioridad=tarea.Prioridad;
        tareaActual.CategoriaId=tarea.CategoriaId;
        tareaActual.Titulo=tarea.Titulo;
        tareaActual.Descripcion=tarea.Descripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    
    return  Results.NotFound();
});
app.MapDelete("/api/tareas/{id}", async([FromServices] TareasContext dbContext,[FromRoute]Guid id) =>{
  
    var tareaActual=dbContext.Tareas.Find(id);
    
    if(tareaActual !=null){
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    
    return  Results.NotFound();
});
app.MapGet("/conexion",async([FromServices] TareasContext dbContext)=>{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+ dbContext.Database.IsInMemory());
}
);
app.Run();
