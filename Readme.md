1. Create Models folder

2. Create your class under Models

3. Create the controller for the model under the Controllers folder

4. Remove the value of launchUrl which by default is WeatherForecast to be empty like "". There are two launchUrls

5. Create folder Pages

6. Add a Razor Page under Pages. A blank Razor Page with the name Index

7. Add services.AddRazorPages(); under the line services.AddControllers();

8. Add:
	app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
under
	app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
9. Build the project

10. In Nuget Manager Console, write add-migration -Context nameOfYourContext. The nameOfYourContext should be in Data folder.

11. It will ask for a name. Give it a name that is different than the context. You can add a simple DB to the name

12. Run the command update-database

13. Put the following tags in your controller:
	[Produces("application/json")] before the class
	[Route("~/api/GetEmp")] before Get function
	[Route("~/api/AddEmp")] before Post function
	[Route("~/api/DeleteEmp/{id}")] before Delete function

14. Add the following line to your controller:
	[Route("~/api/UpdateEmp")]
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody]Emp emp)
        {
            _context.Update(emp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmp", new { id = emp.Id }, emp);

15. Then change the names from Emp to your own table

16. Copy the JQuery texts from Index in Pages to your Index

17. Change the links of your JQuery file