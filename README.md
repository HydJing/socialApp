# Welcome my first .Net App

Hi! This is my first .net app **socialApp**, following tutorial [Build an app with ASPNET Core and Angular from scratch](https://www.udemy.com/course/build-an-app-with-aspnet-core-and-angular-from-scratch/)



# Tech Stack

> .Net Core 3.0.0

> SQLite

> Angular

> Git

> Postman


# Summary Section 1
- Introducing the projects and tech stack


# Summary Section 2
- Create the Web API
- Review the default files created by the DotNetCLI 
- Ensure the Web API runs successfully
- Create our DB using the Code First Approch( model -> migration)
- Add source control (Git)
- Creat eh Angular application by CLI command
- Make HTTP requests from Angular to fetch data from our API
- Bind data from the API to the HTML to display it on the page
- Add support for Bootstrap and Font-Awesome

# Summary Section 3
- How we store passwords in the DB(no password, only hash and hashed value)
- Create User Model Entity
- The Repository Pattern(extra layer between business logic and DB)
- Creating the Authentication Controller
- Data Transfer Objects(DTOs)
- Token Authentication(JWT token)
- Authentication Middleware

# Summary Section 4
- Angular service(authentication service)
- conditionally displaying the elements in the DOM(ngIf)
- Input Properties([(ngModel)]="model.password")
- Output Properties(EventEmitter)

# Summary Section 5
- Error handling in API(using .net core to handle erors)
- Error handling on the client side(in Angular, should show the erro on website page)

# Summary Section 6
- Alertifyjs(pop up message, api response)
- Angular JWT(handle decoding and checking token exists, no security improvement)
- ngx-bootstrap(replacement for JQuery)
- bootswatch(theme)

# Summary Section 7
- Setup the route
- using RouterLinkActive(show active style when matched the route)
- Using Routing in code
- protecting the Routes
- proteching multiple routes at once(grouped ruotes)

# Summary Section 8
- Extending the User class(more DTOs, e.g. UserForListDto, PhotoForDetailedDto)
- more migrations
- Cascade Delete(delete user also delete photo record. Model User.cs)
- seeding more data into our DB(Seed.cs)
- create a new repository for whole app(SocialRepository)
 - Using Automapper(mapping the enity automatically. AutoMapperProfiles)

 # Summary Section 9
- Using types in Typescript
- Retrieving Users from the API(user service)
- Using Bootstrap to create member card(calss card from Bootstrap)
- Adding a Detailed view of the users(page for detail information of user)
- Route resolvers(add data with route)
- Adding a Photo gallery(ngx-gallery)

 # Summary Section 10
- Created a component for editing profile(member-edit component)
- CanDeactiveate Route guard(check unsaved changes before navigate away)
- The @HostListener decorator (used for CanDeactiveate route)
- The @ViewChild decorator (used for access the form in our component typescript file)
- Persisted changes to the API (update the user with member edit page)

 # Summary Section 11
- Where to store the photos(third party service, Cloudinary)
- Added a photos controller(manage all the photo actions in API side)
- NG2 file upload(using plugin to simplfy the upload file process)
- Setting the photo as main(set the specific photos as main)
- Using Filter and Splice(filter to get each item property, splice get item by index position)
- Any to Any component communication(using BehaviorObject to subscribe the updates)

 # Summary Section 12
- Reactive Forms introduction(register form, angular core ReactiveFormsModule)
- Validation(create form group as form builder with validations)
- Custom Validator(check password with confirmPassword)
- Validation Feedback(error message when validation failed)
- The Date problem(use NGX BsDatepickerConfig for birth of date input)
- Hooking it all up to the API(AuthController, UserController and register DTO)

 # Summary Section 13
- Update User last active date time(using NGX-timeago module, using action filter to update last active date time of user when ever user controller been used)