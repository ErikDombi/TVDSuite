# TVDSuite
A .NET library to access [TVDSutie](https://TVDSuite.com/) API
- - -

## Examples

### Logging In
```cs
TVDSuite api = new TVDSuite();
var login = api.Login(textBox1.Text, textBox2.Text);
if (login.Success && permission.Success)
{
  // Logged in
}
else
  MessageBox.Show(login.Message + "\nError Code: " + login, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
```
- - -

## Todo:
 - Add Register Function
