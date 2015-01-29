MultiMonitorHelper
==================

API decided to help manage states/query of multiple monitors, using C# language. 

It allows to manipulate connected displays easily (WinXP, Vista, 7, and 8), and query
information about them. 

The motivation for this library came from the fact that the existing Winforms Screen.cs is useless
for some complex scenarios:

- Does not include latest information about the displays. 
- Has no support to manipulate displays at all.


pInvoke can get very crazy - I spent weeks trying to clone/extend/manipulate monitors on Windows7.
