# Character Roster (ITSE 1430)
## Version 1.2

In this lab you will take the previous Character Roster application and port it to the web using MVC.

*Note: The behavior added in the previous lab should still work correctly including validation of the character at the database level, integration with the SQL database and character name uniqueness.*

[Skills Needed](#skills-needed)\
[Story 1](#story-1)\
[Story 2](#story-2)\
[Story 3](#story-3)\
[Story 4](#story-4)\
[Story 5](#story-5)\
[Story 6](#story-6)\
[Story 7](#story-7)\
[Requirements](#requirements)

## Skills Needed

- C#
  - Attributes
- ASP.NET MVC
  - Controllers
  - Views
  - ViewModels

## Story 1

Create the web project.

- Create a new `ASP.NET Web Application (.NET Framework)`. Select the framework as `.NET 4.7.2`.
- Call the project `<App>.Web` where `<App>` is the name of your existing project to avoid issues with namespaces.
- Add the project to the current solution.
- Select the `MVC` option.
- For `Advanced` only the `Configure for HTTPS` option is needed.
- Update the references to allow the MVC project to use the existing Nile business library.
- Update the `web.config` to reference the database connection string.

*Note: There is a known bug in Visual Studio related to web applications. If you get an error when running the application and it complains about not finding a `bin/roslyn` folder then restart Visual Studio and rebuild. This will generate the necessary folder structure.*

### Acceptance Criteria

- Project compiles cleanly.

## Story 2

Add a view model to support displaying the characters.

- Implement the view model in the MVC project.
- Use attributes to handle validation of the model properties.
- Implement `IValidatableObject` to handle any validation that cannot be done using attributes.
- Remove all validation from `Validate` method that is handled by an attribute.

### Acceptance Criteria

- View model is properly defined.
- View model validates the product information.

## Story 3

Implement character listing.

Implement the controller and view to display the list of characters.

- Add a new controller to manage the characters. Name it accordingly.
- Define an `Index` action to show the list of characters (using the view models).
- Retrieve the data from the database, convert to view models and pass to the underlying view.
- Generate the view to back the action.
- Ensure the characters are ordered by name.

### Acceptance Criteria

- When navigating to the URL the list of characters is shown with options for `Edit`, `Delete`, `Details`.
- Characters are properly ordered.

## Story 4

Implement character details.

- Add the appropriate action to the controller. It should take the character's ID.
- Fetch the character from the database, convert to a view model and pass to the view.
- If the character does not exist then return `HttpNotFound`.
- Generate the view to back the action.
- Ensure the character is displayed properly.

### Acceptance Criteria

- Clicking `Details` on list page goes to correct character details page.
- Character is properly rendered.
- Clicking `Back` returns to the list page.

## Story 5

Implement character deletion.

- Add the appropriate action to the controller. It should take the character's ID.
- Fetch the character from the database, convert to a view model and pass to the view.
- If the character does not exist then return `HttpNotFound`.
- Generate the view to back the action.
- Ensure the character is displayed properly.

Handle the delete process.

- Implement the POST action to handle the user confirming delete. It should take the character view model.
- On post remove from the database and return to the list view.

### Acceptance Criteria

- Clicking `Delete` on list page goes to correct character delete page.
- Character is properly rendered.
- Clicking `Delete` removes the character and returns to the list page.
- Clicking `Back` returns to the list page.

## Story 6

Implement character edit.

- Add the appropriate action to the controller. It should take the character's ID.
- Fetch the character from the database, convert to a view model and pass to the view.
- If the character does not exist then return `HttpNotFound`.
- Generate the view to back the action.
- Ensure the character is displayed properly.
- Ensure character validation is working properly.

Handle the saving process.

- Implement the POST action to handle the user saving. It should take the character view model.
- On post save to the database and redirect to the details page.
- If any errors occur update model state and return to the edit page so user can see error message.

### Acceptance Criteria

- Clicking `Edit` on list page goes to correct character page.
- Clicking `Edit` on product details page goes to the correct character page.
- Character is properly rendered.
- Validation is working.
- Clicking `Save` updates the character and returns to the details page.
- Clicking `Save` and having an error (e.g. duplicate title) causes the edit page to be shown with the appropriate message.
- Clicking `Back` returns to the list page.

## Story 7

Implement new character.

- Add the appropriate action to the controller.
- Generate the view to back the action.
- Ensure the character is displayed properly.
- Ensure character validation is working properly.

Handle the saving process.

- Implement the POST action to handle the user saving. It should take the character view model.
- On post save to the database and redirect to the details page.
- If any errors occur update model state and return to the add page so user can see error message.

### Acceptance Criteria

- Clicking `Create new` on list page goes to correct page.
- Character is properly rendered.
- Validation is working.
- Clicking `Save` adds the character and returns to the details page.
- Clicking `Save` and having an error (e.g. duplicate title) causes the add page to be shown with the appropriate message.
- Clicking `Back` returns to the list page.

## Story 8

Adjust the Home Page.

Fix the application name.

- Change the `Application Name` title to `Character Roster`.
- Change the site title from `My ASP.NET Application` to `Character Roster`.
- Change the copyright footer to your name (e.g. `© Your Name`).

Remove links from home page.

- Remove the `Home` link from the header.
- Remove the `About` link from the header.
- Remove the view and action as well.

Update the contact page

- Update the `Contact` view to contain the course name, semester and your name.

Clean up home page.

- Remove all the content from the `div` with class `jumbotron` except the `h1`.
- Set the contents of the `h1` to `Character Roster`.
- Remove the `div` with class `row` and all its content.

Add link for characters.

- Add a link called `Characters` to the header in place of `Home`. It should go to the character list page.

### Acceptance Criteria

- Home page contains link to characters.
- Home page does not contain extra content.
- Home page does not contain link to about content.
- Contact page contains student information.
- Browser title bar and page header contains appropriate title.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.