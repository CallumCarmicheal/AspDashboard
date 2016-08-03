#How it works
AspDashboard comes with a built in global configuration system that stores it values in a database. 
These values can be changed and accessed from within the code via your own means or the granted means 
of ```AspDashboard.Classes.Util.Config.Get()```, This configuration is cached and will be reloaded
every 30 minutes to help with the speed of the whole site. 

How to print a value:
for example we will use ```site_name```, to print this value into html you will want to do 
```
@using AspDashboard.Classes.Util
@(new HtmlString(Config.Get().getString("site_name", "ERROR"))
```
What code above will do is use the namespace AspDashboard.Classes.Util and then Get the cache and get the setting "site_name", 
and if the setting does not exist - the value "ERROR" will be returned by default. 

#Please Note

IF ```framework_config_missing_reload``` is set to 1 THEN the config will be reloaded if the setting does not exist.

IF ```framework_config_missing_insert``` is set to 1 THEN (If the config can be reloaded it will be done before this) the default 
value will be inserted into the database to stop any future errors.

#Caching
Where is it Cached:
The configuration object is cached into ASP.Net's HttpContext Cache.

Changing the Caching Expiration Time:
You will find the expiration time variable in the method ```AspDashboard.Classes.Util.Config.Refresh```.