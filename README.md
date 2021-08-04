# TaskManager

To un:

1-Change the connection string in app.settings file to your sqlserver cnnection 

2-Set TaskManager.Dal as startup 

3-in Package console manager choose TaskManager.Dal from the drop down

4- Run the command $env:TaskManagersConnectionString  = "{your connection string}"

5-Run the command : update-database

6-Set TaskManager.Web as your startup project

7-Run and enjoy testing :) !

**************************************************************************************************************

About the patterns in the project:

1-Used startegy pattern to make the sorting algorithms interchangable when we add more

2-Used the decorator pattern to extend the proceess dto behaviour in run time 

3-Used template pattern to gather the common behaviours between the different vendor for memory managment and delegated what is varying to the sub classes

4-Used factories for insatncing objects.
**************************************************************************************************************

To be added unit testing
