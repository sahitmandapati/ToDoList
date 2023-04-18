// import the required namespace
using ToDoList.Services;

// create a new instance of the WebApplication builder with the given command-line arguments
//The args parameter is an array of command-line arguments that can be passed to the application at runtime.

//The WebApplication builder is used to configure and build the application's dependency injection container, configure the HTTP request pipeline, and start the application. By creating an instance of the builder, the application can be configured and built programmatically.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// register the controllers with the dependency injection container
builder.Services.AddControllers();

// add support for generating Swagger/OpenAPI documentation for the API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register a singleton instance of the TodoItemService class with the dependency injection container
builder.Services.AddSingleton<TodoItemService>();

// Build the WebApplication instance
var app = builder.Build();

// Configure the HTTP request pipeline.
// if the application is running in development mode, enable Swagger documentation and UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// configure the HTTP pipeline to redirect all HTTP requests to HTTPS
app.UseHttpsRedirection();

// configure the HTTP pipeline to use authorization
app.UseAuthorization();

// configure the HTTP pipeline to handle incoming HTTP requests by matching them to their respective controller action methods
app.MapControllers();

// start the application
app.Run();
