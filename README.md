# TVDSuite
A .NET library to access [TVDSutie](https://TVDSuite.com/) API
- - -

## Examples

### Initializing
```cs
TVDSuite api = new TVDSuite();
```

### Logging In
```cs

var login = api.Login("Username", "Password");
if (login.Success)
{
  // Logged in
}
else
  MessageBox.Show(login.Message + "\nError Code: " + login.Code, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
```

### Getting Permission
```cs
var permission = api.GetPermission("TVDSuite.TVDSteam");
if (permission.Success)
{
  // User has permission
}
else
  MessageBox.Show(permission.Message + "\nError Code: " + permission.Code, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
```
- - -

## Notes:
If you need a custom permission node created, you can email erik@tvdsuite.com

## Todo:
 - Add Register Function
