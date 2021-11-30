# BooksWebAPI

The solution contains 4 projects :
-BooksDAL : The project contains data access layer for table books using entity framework.
-DataSync: It contains API to fetch data from Google books api.
-SeachableBooksWebAPI : The web api to display the table of books. 
Since there is no hosting done, the database is created on the local sql db. The same has been passed in the Web.config file which can be overwritten as required.
When the call to the controller is made to fetch data from db, there is a check if the db does not contains any data, 
it makes a call to the DataSync API which fetchs the data from the Google API and inserts it to our database.

Before running the web api, we need to edit the web.config for updating the connection string details.

Just thinking out loud here, since being on a time crunch here, mentioning the some points that could enhance our solution:
-Repository pattern could be used in BooksDAL layer.
-pagination could be used to retrieve more data from Google API. Since there was count limit, only 40 records could be fetched.
-Dependency injection could be used creating the Startup class.
