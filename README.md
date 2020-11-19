# Welcome to my first .Net App

Hi! This is my first .net app **socialApp**, following tutorial [Build an app with ASPNET Core and Angular from scratch](https://www.udemy.com/course/build-an-app-with-aspnet-core-and-angular-from-scratch/)


# Tech Stack

> .Net Core 3.0.0

> SQLite

> Angular

> Git

> Postman


# Demo Screenshots
- Homepage
![homepage_image](https://user-images.githubusercontent.com/9813209/99203004-fe408e80-2815-11eb-88b0-3a168a20f3fc.png)

- Signup Page
![signup_image](https://user-images.githubusercontent.com/9813209/99203009-ff71bb80-2815-11eb-8f46-ed8b22cbb1db.png)

- Matches Page
![matches_image](https://user-images.githubusercontent.com/9813209/99203010-ff71bb80-2815-11eb-891b-781380a1a952.png)

- List Page
![list_page](https://user-images.githubusercontent.com/9813209/99203006-fed92500-2815-11eb-9ede-77c6db6005ec.png)

- Messages Page
![messages page](https://user-images.githubusercontent.com/9813209/99202994-fa147100-2815-11eb-91a5-55869dbd1832.png)

- Detail Information Page
![detail Logo](https://user-images.githubusercontent.com/9813209/99202995-fa147100-2815-11eb-843b-88c79c0b83cc.png)
![photo Logo](https://user-images.githubusercontent.com/9813209/99203003-fda7f800-2815-11eb-9a75-1ee81e3b8681.png)
![message Logo](https://user-images.githubusercontent.com/9813209/99202999-fc76cb00-2815-11eb-8657-9f6cc154a853.png)

- Acount Detail Page
![acount Logo](https://user-images.githubusercontent.com/9813209/99202987-f84aad80-2815-11eb-8459-8603ef0270ba.png)
![accountimage Logo](https://user-images.githubusercontent.com/9813209/99202986-f7198080-2815-11eb-8bd6-127942a6d1bc.png)

- Admin Pages
![Admin - Users](https://user-images.githubusercontent.com/9813209/99203939-eddde300-2818-11eb-91ad-4808f8fb03cc.png)
![adminphoto Logo](https://user-images.githubusercontent.com/9813209/99202990-f8e34400-2815-11eb-9f33-9710f0f47545.png)



# Summary Of Section 1
- Introducing the projects and tech stack


# Summary Of Section 2
- Create the Web API
- Review the default files created by the DotNetCLI 
- Ensure the Web API runs successfully
- Create our DB using the Code First Approch( model -> migration)
- Add source control (Git)
- Creat eh Angular application by CLI command
- Make HTTP requests from Angular to fetch data from our API
- Bind data from the API to the HTML to display it on the page
- Add support for Bootstrap and Font-Awesome

# Summary Of Section 3
- How we store passwords in the DB(no password, only hash and hashed value)
- Create User Model Entity
- The Repository Pattern(extra layer between business logic and DB)
- Creating the Authentication Controller
- Data Transfer Objects(DTOs)
- Token Authentication(JWT token)
- Authentication Middleware

# Summary Of Section 4
- Angular service(authentication service)
- conditionally displaying the elements in the DOM(ngIf)
- Input Properties([(ngModel)]="model.password")
- Output Properties(EventEmitter)

# Summary Of Section 5
- Error handling in API(using .net core to handle erors)
- Error handling on the client side(in Angular, should show the erro on website page)

# Summary Of Section 6
- Alertifyjs(pop up message, api response)
- Angular JWT(handle decoding and checking token exists, no security improvement)
- ngx-bootstrap(replacement for JQuery)
- bootswatch(theme)

# Summary Of Section 7
- Setup the route
- using RouterLinkActive(show active style when matched the route)
- Using Routing in code
- protecting the Routes
- proteching multiple routes at once(grouped ruotes)

# Summary Of Section 8
- Extending the User class(more DTOs, e.g. UserForListDto, PhotoForDetailedDto)
- more migrations
- Cascade Delete(delete user also delete photo record. Model User.cs)
- seeding more data into our DB(Seed.cs)
- create a new repository for whole app(SocialRepository)
 - Using Automapper(mapping the enity automatically. AutoMapperProfiles)

 # Summary Of Section 9
- Using types in Typescript
- Retrieving Users from the API(user service)
- Using Bootstrap to create member card(calss card from Bootstrap)
- Adding a Detailed view of the users(page for detail information of user)
- Route resolvers(add data with route)
- Adding a Photo gallery(ngx-gallery)

 # Summary Of Section 10
- Created a component for editing profile(member-edit component)
- CanDeactiveate Route guard(check unsaved changes before navigate away)
- The @HostListener decorator (used for CanDeactiveate route)
- The @ViewChild decorator (used for access the form in our component typescript file)
- Persisted changes to the API (update the user with member edit page)

 # Summary Of Section 11
- Where to store the photos(third party service, Cloudinary)
- Added a photos controller(manage all the photo actions in API side)
- NG2 file upload(using plugin to simplfy the upload file process)
- Setting the photo as main(set the specific photos as main)
- Using Filter and Splice(filter to get each item property, splice get item by index position)
- Any to Any component communication(using BehaviorObject to subscribe the updates)

 # Summary Of Section 12
- Reactive Forms introduction(register form, angular core ReactiveFormsModule)
- Validation(create form group as form builder with validations)
- Custom Validator(check password with confirmPassword)
- Validation Feedback(error message when validation failed)
- The Date problem(use NGX BsDatepickerConfig for birth of date input)
- Hooking it all up to the API(AuthController, UserController and register DTO)

 # Summary Of Section 13
- Update User last active date time(using NGX-timeago module, using action filter to update last active date time of user when ever user controller been used)

 # Summary Of Section 14
- Paging in the API/SPA
- filtering in the API/SPA
- sorting in the API/SPA
- new class params with age, gender and orderby. default value in API, passing thought router and added in Angular to show the filters.

 # Summary Of Section 15
- Defining Relationships in EF(one to many, many to many, defined the relationship in class dataContext)
- Using the Fluent API(chaining method, multiple include())
- add like function in Angular(make heart icon works)

# Summary Of Section 16
- The message entity(controller, model and DTO)
- CRUD(create message, get message, update message and delete mesage, in message controller class)
- Inbox, Outbox, Unread messages(to fetch different messages to show in the list)
- Add a 'chat' design to the messaging system(chat window)
- adding the 'Mark as Read' functionality(when load the messages, also mark the message as read if the message recipient id equals current user id)
- Deleting messages(delete the message only for current user, the recipietn might still have the message)
