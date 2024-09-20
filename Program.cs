using System.Text.Json;
using System.Text.Json.Serialization;
using Client.Model;
using Client.Service.CourseService;
using Client.Service.GroupService;
using Client.Service.MentorGroupService;
using Client.Service.MentorService;
using Client.Service.StudentGroupService;
using Client.Service.StudentService;
using Dapper;
using Npgsql;
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5132/");
builder.WebHost.ConfigureKestrel(options => { options.AllowSynchronousIO = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();
string connectionString = "Host = localhost; User Id = postgres; Port = 4321; Database = web_db; Password = salom";

CourseService courseService = new CourseService();
GroupService groupService = new GroupService();
MentorGroupService mentorGroupService = new MentorGroupService();
MentorService mentorService = new MentorService();
StudentGroupService studentGroupService = new StudentGroupService();
StudentService studentService = new StudentService();
app.MapGet("/api/courses", async () =>
{
     IEnumerable<Course> courses = await courseService.GetAll();
     return Results.Json(courses);
});
 
app.MapGet("/api/courses/{id}", async(int id) =>
{
    Course? course = await courseService.GetById(id);
    if(course==null) return Results.NotFound(new{message = "not found"});
    return Results.Json(course);
});
 
app.MapDelete("/api/courses/{id}", async (int id) =>
{
    bool course = await courseService.DeleteAsync(id);
    if(course==false) return Results.NotFound(new{message = "not deleted"});
    return Results.Ok(new {message = "deleted"});
});
 
app.MapPost("/api/courses", async (Course course)=>{

    bool res = await courseService.CreateAsync(course);
    if(res==false) return Results.NotFound(new{message = "not created"});
    return Results.Ok(new {message = "created"});
});
 
app.MapPut("/api/courses", async(Course course) => {
 
    bool res = await courseService.UpdateAsync(course);
    if(res==false) return Results.NotFound(new{message = "not updated"});
    return Results.Ok(new {message = "updated"});
});
app.MapGet("/api/groups", async () =>
{
    IEnumerable<Group> groups = await groupService.GetAll();
    return Results.Json(groups);
});
 
app.MapGet("/api/groups/{id}", async (int id) =>
{
    Group? group = await groupService.GetById(id);
    if(group==null) return Results.NotFound(new{message = "not found"});
    return Results.Json(group);
});
 
app.MapDelete("/api/groups/{id}", async (int id) =>
{
    bool group = await groupService.DeleteAsync(id);
    if(group==false) return Results.NotFound(new{message = "not deleted"});
    return Results.Ok(new {message = "deleted"});
});
 
app.MapPost("/api/groups", async (Group group)=>{

    bool res = await groupService.CreateAsync(group);
    if(res==false) return Results.NotFound(new{message = "not created"});
    return Results.Ok(new {message = "created"});
});
 
app.MapPut("/api/groups", async (Group group) => {
 
    bool res = await groupService.UpdateAsync(group);
    if(res==false) return Results.NotFound(new{message = "not updated"});
    return Results.Ok(new {message = "updated"});
});
app.MapGet("/api/mentor_group", async () =>
{
    IEnumerable<MentorGroup> mentorGroups = await mentorGroupService.GetAll();
    return Results.Json(mentorGroups);
});
 
app.MapGet("/api/mentor_group/{id}", async(int id) =>
{
    MentorGroup? mentorGroup = await mentorGroupService.GetById(id);
    if(mentorGroup==null) return Results.NotFound(new{message = "not found"});
    return Results.Json(mentorGroup);
});
 
app.MapDelete("/api/mentor_group/{id}", async(int id) =>
{
    bool mentor_group = await mentorGroupService.DeleteAsync(id);
    if(mentor_group==false) return Results.NotFound(new{message = "not deleted"});
    return Results.Ok(new {message = "deleted"});
});
 
app.MapPost("/api/mentor_group", async(MentorGroup mentorGroup)=>{

    bool res = await mentorGroupService.CreateAsync(mentorGroup);
    if(res==false) return Results.NotFound(new{message = "not created"});
    return Results.Ok(new {message = "created"});
});
 
app.MapPut("/api/mentor_group", async(MentorGroup mentorGroup) => {
 
    bool res = await mentorGroupService.UpdateAsync(mentorGroup);
    if(res==false) return Results.NotFound(new{message = "not updated"});
    return Results.Ok(new {message = "updated"});
});
app.MapGet("/api/mentors", async () =>
{
    IEnumerable<Mentor> mentors = await mentorService.GetAll();
    return Results.Json(mentors);
});
 
app.MapGet("/api/mentors/{id}", async (int id) =>
{
    Mentor? mentor = await mentorService.GetById(id);
    if(mentor==null) return Results.NotFound(new{message = "not found"});
    return Results.Json(mentor);
});
 
app.MapDelete("/api/mentors/{id}", async (int id) =>
{
    bool mentor = await mentorService.DeleteAsync(id);
    if(mentor==false) return Results.NotFound(new{message = "not deleted"});
    return Results.Ok(new {message = "deleted"});
});
 
app.MapPost("/api/mentors", async (Mentor mentor)=>{

    bool res = await mentorService.CreateAsync(mentor);
    if(res==false) return Results.NotFound(new{message = "not created"});
    return Results.Ok(new {message = "created"});
});
 
app.MapPut("/api/mentors", async (Mentor mentor) => {
 
    bool res = await mentorService.UpdateAsync(mentor);
    if(res==false) return Results.NotFound(new{message = "not updated"});
    return Results.Ok(new {message = "updated"});
});
app.MapGet("/api/student_group", async () =>
{
    IEnumerable<StudentGroup> studentGroups = await studentGroupService.GetAll();
    return Results.Json(studentGroups);
});
 
app.MapGet("/api/student_group/{id}", async (int id) =>
{
    StudentGroup? studentGroup = await studentGroupService.GetById(id);
    if(studentGroup==null) return Results.NotFound(new{message = "not found"});
    return Results.Json(studentGroup);
});
 
app.MapDelete("/api/student_group/{id}", async (int id) =>
{
    bool studentGroup = await studentGroupService.DeleteAsync(id);
    if(studentGroup==false) return Results.NotFound(new{message = "not deleted"});
    return Results.Ok(new {message = "deleted"});
});
 
app.MapPost("/api/student_group", async (StudentGroup studentGroup)=>{

    bool res = await studentGroupService.CreateAsync(studentGroup);
    if(res==false) return Results.NotFound(new{message = "not created"});
    return Results.Ok(new {message = "created"});
});
 
app.MapPut("/api/student_group", async (StudentGroup studentGroup) => {
 
    bool res = await studentGroupService.UpdateAsync(studentGroup);
    if(res==false) return Results.NotFound(new{message = "not updated"});
    return Results.Ok(new {message = "updated"});
});
app.MapGet("/api/students", async () =>
{
    IEnumerable<Student> students = await studentService.GetAll();
    return Results.Json(students);
});
 
app.MapGet("/api/students/{id}", async (int id) =>
{
    Student? student = await studentService.GetById(id);
    if(student==null) return Results.NotFound(new{message = "not found"});
    return Results.Json(student);
});
 
app.MapDelete("/api/students/{id}", async (int id) =>
{
    bool student = await studentService.DeleteAsync(id);
    if(student==false) return Results.NotFound(new{message = "not deleted"});
    return Results.Ok(new {message = "deleted"});
});
 
app.MapPost("/api/students", async (Student student)=>{

    bool res = await studentService.CreateAsync(student);
    if(res==false) return Results.NotFound(new{message = "not created"});
    return Results.Ok(new {message = "created"});
});
 
app.MapPut("/api/students", async (Student student) => {
 
    bool res = await studentService.UpdateAsync(student);
    if(res==false) return Results.NotFound(new{message = "not updated"});
    return Results.Ok(new {message = "updated"});
});
app.Run();
