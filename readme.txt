
This repo is available to use as a "teaching" project for learning how to utilize 
MonoCross.  The example app has limited functionality, used to demonstrate 
one way to structure the navigation and UI code in your MonoCross based apps.

This code base includes an MonoDroid.Dialog fork.  Using the dialog framework
a screen in this example app shares abstract UI using the dialog framework's
Element constructs.  This is rudimentary and needs improved support.


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
Contains as its base the MonoCross micro framework, source version 1.2 as
was available on google code at this time (5/20/2012). Some changes have been
made to the MonoCross.Droid and MonoCross.Touch source.  This is common of
projects built on the MonoCross libraries because some (albeit minor) 
amounts of app centric navigation often occurs at that level.  This generally
applies to apps with a Tab-bar, or tablet apps utilizing split screen 
navigation. For a demo explaining that concept, search for the 
MonoCross_Helpers github project and explore that source.

