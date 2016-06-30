<h3>Description</h3>
<div>
Angular Meeting Manager is a sample project I created as an example of how to create a larger scale SPA using .NET Web API 

(C#), Angular 1, and SQL Server.
<div>

<h3>Requirements</h3>
<div>
The project was created using
<ul>
<li>Visual Studio 2013 Ultimate.  You should be able to use any version of Visual Studio 2013.</li>
<li>Angular 1.5.5</li>
<li>SQL Server Express 10.50.1790 (SQL Server 2008 R2)</li>
<li>Web API 5.2.3</li>
</ul>
</div>

<h3>Database Set-Up</h3>
<div>
You should be able to use any version of SQL Server 2008 R2 and above.  I used SQL Server Express 10.50.1790.  The connection 

string in the web.config file is 
<div>&lt;add name="AMMDb" connectionString="Data Source=.\sqlexpressdev;Initial 

Catalog=AngularMeetingManager;uid=roomsuser;password=room5@cct;" providerName="System.Data.SqlClient" /&gt;</div>
</div>
<br/>
<div>
You'll need to change the "Data Source=.\sqlexpressdev" property to the database server you are using.
</div>
<br/>
<div>
These steps will work for the above connection string.  You can alter these steps but you'll need to alter the connection 

string in the web.config file.
</div>
<div>
<ol>
<li>Open SQL Server Management Studio.</li>
<li>Connect to the database server you will be using.</li>
<li>Create a database called AngularMeetingManger.</li>
<li>
Under Security>Logins, create a new login:
  <div>Login name: roomsuser</div>
  <div>Select SQL Server authentication</div>
  <div>Password: room5@cct</div>
  <div>Default database: AngularMeetingManager</div>
</li>
<li>Expand the AngularMeetingManager database.</li>
<li>In Security, select "New User".</li>
<li>
Select "SQL user with login" and input:
  <div>User name: roomsuser</div>
  <div>Login name: roomsuser</div>
  <div>Default schema: dbo</div>
</li>
</ol>
</div>

<div>
You should be able to download the project, make any changes to the web.config file, and run the application.
</div>

<h3>Notes</h3>
<div>
In this application, I've tried to follow John Papa's <a href="https://github.com/johnpapa/angular-styleguide/">Angular Style 

Guide</a>.  I do diverge from a strict adherence to his guide, at time by choice and at time due to lack of understanding or 

knowledge of his style guide.
</div>
<br/>
<div>
In the current version of this application I use ADO.NET to do data access rather than use an ORM like Entity Framework.  

This was not because I think using ADO.NET is better than using an ORM, quite the contrary.  In my professional work many of 

our legacy applications use ADO.NET and I thought it would be interesting to see if I could write a Web API application with 

Angular using ADO.NET for the data access.  In the future I plan to convert the data access to Entity Framework.
</div>
