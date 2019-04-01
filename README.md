# SQL ADO Helper
This DLL for beginners who always face issues with database connection and CRUD operation using c#
With this DLL you can insert update delete or get data from SQL server easy and efficient 
What you should do 
1-	Create SQL connection in appconfig file you will find comment
 <!--add your connection string here--> replace this with your connection string 
2-	Then you need to create view model, view model are just simple class contain properties hold the same names of database table you will deal with 
3-	View model example 
 


# Examples:

## Insert new user 
1- create sql connection object 


2- store your sql query in variable in insert case will be $"inert into users values ({'username'},{'password'},{DateTime.Now})";


3- create object of sql ado helper : 

var connection = ConfigurationManager.ConnectionStrings["your connection string name"].ConnectionString;
            var query = $"inert into users values ('Moath','123QWE',{DateTime.Now})";
               SQLHelper<int> sQLHelper = new SQLHelper<int>(connection, query);
             sQLHelper.ExecuteNonQuery();
             
## Get The Count Of Users
1- create sql connection object 

2- store your sql query in variable in select one value case will be $"select count(*) from users";

3- create object of sql ado helper : 

 var query = $"select count(*) from users";
               SQLHelper<int> sQLHelper = new SQLHelper<int>(connection, query);
           var usersCount = sQLHelper.ExecuteScaler();
  
## Get All Users

1- create sql connection object 

2- store your sql query in variable in select one value case will be $"select * from users";

3- create object of sql ado helper : 

 var query = $"select * from users";
               SQLHelper<int> sQLHelper = new SQLHelper<int>(connection, query);
            var List<Users> users = sQLHelper.ExecuteReader();
  
  
  ## Notes
  
  ### All methods have async version 
  
  ### hope this helpful for you 
  
  if you have any questions or any issues you can contact me on dev.moath.naji@gmail.com :)
