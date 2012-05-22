
This repo is available to use as "teaching" project for learning monocross
techniques.  The example app has limited functionality, used to demonstrate 
one way to structure the navigation and UI code in your MonoCross apps.



"ExampleApp" folder
An abstract Example app containing the Controller, Model, and navigation
routes.  Notice both the Android and the iOS projects reference the same
C# files.

"ExampleApp.Droid" folder
Contains the executable for the android version of the app.  Build to an
.apk file for loading on a device.

ExampleApp.Touch" folder
Contains the executable for the iOS version of the app

"MonoCross" folder
Contains as a base the MonoCross micro framework, source version 1.2 and as
available on google code at this time (5/20/2012).  Some changes made have
been made to the MonoCross.Droid and MonoCross.Touch source.  This is
common of MonoCross projects because some (albeit minor) amounts of app
centric navigation of occurs at that level.  This generally applies to
apps with a Tab-bar or tablet apps utilizing split screen navigation. For
a demo explaining the concept, search for the MonoCross_Helpers github
project and explore that source.

