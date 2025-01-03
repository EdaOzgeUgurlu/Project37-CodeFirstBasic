﻿using Microsoft.EntityFrameworkCore;
using Project37_CodeFirstBasic.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PatikaFirstDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}/////////////ffgg

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();