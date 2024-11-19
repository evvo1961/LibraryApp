An asp.net core api to manage books - list all books, display single book by id, add books, update a book, delete books

Visual Studio solution set to run multiple projects
LibraryAppApi
LibraryAppUI

The UI project can manage the actions that call the api endpoints.

Api url - https://localhost:7100/api/

In addition to the UI there is a swagger page that also contains all the api endpoints for testing

Swagger endpoint - https://localhost:7100/swagger/index.html

There is an additional vue project at: 
LibraryApp\libraryapp-client that displays the list of books

npm run dev

runs at http://localhost:8080/

Additional features given time would be to add Authentication JWT? OAuth?
Add the add/update/delete functionality to the vue project
