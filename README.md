# CSharp_02
CSharp-02 , start  06/03/21

###

|week1 - week10|
| Gün  | Saat |
| ------------- | ------------- |
| Şənbə  | 10:30-14:30  | 
| Bazar  | 10:30-14:30  |


|week11 - todo|
| Gün  | Saat |
| ------------- | ------------- |
| Şənbə  | 18:00-22:00  | 
| Bazar  |  18:00-22:00  |

21/08/21
|week12 - todo|
| Gün  | Saat |
| ------------- | ------------- |
| Şənbə  | 18:00-22:00  |

### Student list
- [Fidan Xanlarova](https://github.com/fidan-xanlarovaa/PragmatechCsharpProject)
- [Elcan Seyidov](https://github.com/Elcan-code/PragmatechCsharpProject.git)
- [Rəşad Məmmədov](https://github.com/rashadmemmedov/PragmatechCsharpProject.git)


# Week01-Day01 06/03/21
.................................

# Week01-Day02 06/03/22

### Topics
    - C# haqqinda umumi melumat
    - .Net Framework ve .Net Core haqqinda melumat ve arasindaki ferqler
    - Compiler Haqqinda
    - [Visual Studio IDE nin yuklenmesi](https://visualstudio.microsoft.com/tr/)
    - Visual Studio ile tanisliq , github reposunun clone edilmesi , yeni proyektin yaradilmasi , run edilmesi ve sair

### Resources
- [Tutorial Teacher](https://www.tutorialsteacher.com/csharp/csharp-tutorials)
- [Tutorialspoint](https://www.tutorialspoint.com/csharp/index.htm)


# Week02-Day01 13/03/22

### Topics
    - Microsoft Intermediate Language (MSIL) or Intermediate Language (IL)
    - Common Language Runtime (CLR)
    - Just in Time (JIT)
    - Console Application Intro
    - Console.Write(), Console.WriteLine(), Console.ReadLine()
    - Program.cs
    - Main method
    - c# 9.0 Main Method Top Level Statements
    - Debugging
    - C# Coding Standards and Naming Conventions
    - Comment, #region , todo ( task list)
    - C# - Keywords
    - C# - Data Types

### Resources
- [C# Coding Standards and Naming Conventions](https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md)

# Week02-Day02 14/03/22

### Topics
    - Basic Syntax
    - Data Types
    - Value types
    - Reference types 
    - Variables  
    - Defining Variables
    - Initializing Variables
    - Type Conversion
    - Implicit casting
    - Explicit casting
    - Type Conversion Methods
    - Convert metod
    - Parse metod
    - Special Conversion (bool, char)
    
### Tasks
   - [C# - Operators](https://www.tutorialspoint.com/csharp/csharp_operators.htm)
   - [C# - Decision Making](https://www.tutorialspoint.com/csharp/csharp_decision_making.htm)

### Exam
    1. C# programlashdirma dilinde yeni bir deyishen nece teyin edilir ?
    
    - deyisenadi data tipi;
    - deyisenadi;
    - data tipi deyisen adi;
    
    2. int num1 = 10; teyin edilen bu deyisen RAM-da hansi hissede saxlanilir 
    ve RAM uzerindeki davranis  sekili necedir ?
    
    - Stack-de saxlanilir , Stack hissesinde local deyisenler oz deyerini saxlayaraq 
    kopyalanaraq coxalirlar;
    - Heap hissesinde saxlanilir , referansi stack-de deyeri heap-de olur;
    - Static hissede saxlanilir , butun scope-larda elcatandir;
    
    3. int num1 = 10;
       int num2 = 30;
       int num3 = num2;
       num3 = 100;
       yuxarida teyin edilen deyisenlerin (num1,num2,num3) aldiqlari deyerler hansilardir?
       
    - num1 = 10;
      num2 = 30;
      num3 = 100;
      
    - num1 = 10;
      num2 = 100;
      num3 = 100;
      
    - num1 = 10;
      num2 = 100;
      num3 = 30;
         
    4. checked ifadesi ne zaman istifade edilmelidir ?
         
    - Explicit Casting zamani data itkisinin önemli olmadigi veziyyetlerde.
      C# checked ifadesi istifadeciye xeta mesaji vermeden islemeye davam edir;
      
    - Explicit casting zamani data itkisinin önemli oldugu veziyyetlerde.
      C# checked ifadesi istifadeciye xeta mesaji verir ;
    
    - Implicit casting zamani istifade edilir;
  
    5. int num1 = 100;
       object obj1 = (int)num1;
       yuxaridaki num1 deyisenin object-e cevrilmesi nece adlanir ?
       
    - object obj1 = (int)num1;// Unboxing
    - object obj1 = (int)num1;// Boxing
    - object obj1 = (int)num1;// Sadece deyisen teyin edilib . Yuxaridakilardan hec biri.


# Week03-Day01 27/03/21

### Topics
    - C# - Operators
    - Arithmetic Operators
    - Relational Operators
    - Logical Operators
    - string ifadeler-de + , += , == opretatorlarinin istifadesi
    - Deyil ! != beraber deyilse
    - Ternary Operators
    - Member access .
    - TypeOf operator
    - Default operator
    - is operator
    - is null , is not null
    - as operator
    - ? Nullable , ?? Null Coalescing, ??= Null Coalescing
    - C# - Decision Making
    - If Else , Else If statement
    

# Week03-Day02 28/03/21

### Topics
    - C# - Decision Making
    - If Else statement
    - Ternary Operator ?:
    - Switch Statement
    - Switch Statement : goto
    - Switch Statement : when
    - Switch expressions c# 8.0
    - C# - Loops
    -  - for Loop
    -  - while Loop
    -  - do while Loop
    -  - nested loop
    -  - infinite loop


    
### Tasks
   - [Week3.Tasks](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/ConsoleApps/Week3/Week3.Tasks/Program.cs)



# Week04-Day01 03/04/21

### Topics
    - C# Pattern Matching
    - -Type Pattern
    - -Constant Pattern
    - -Var Pattern
    - -Recursive Pattern
    - -Simple Type Pattern
    - -Relational Pattern


### Resources
- [C# 9.0: Improved Pattern Matching](https://www.thomasclaudiushuber.com/2021/02/18/c-9-0-improved-pattern-matching/)
- [Intro To Pattern Matching - Covers C# 9](https://www.c-sharpcorner.com/article/intro-to-pattern-matching-covers-c-sharp-9/)

# Week04-Day02 04/04/21

### Topics
    - Keywords
    - - continue
    - - break
    - - goto
    - - return
    - Array
    - - array loop
    - - Array class
    - - - Array class methods
    - - - -clear
    - - - -copy
    - - - -reverse
    - - - -sort
    - - - -indexOf
    - - - -createInstance
    - c# 8.0 ranges  and indices System.Ranges-System.Index opearator .. ^
    - Multidimensional Array
    - C# Jagged Arrays: An Array of Array

### Tasks
   - [Week4.Tasks](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/ConsoleApps/Week4/Week4.Tasks/Program.cs)


# Week05-Day01 10/04/21

### Topics
    - Collections
    - -Comparison of Array and Collections 
    - -ArrayList // index value pair
    - --Add, AddRange,
    - --Remove, RemoveRange,RemoveAt
    - --Capacity, Count,
    - --Sort , Reverse,
    - --toArray,
    - --Contains(),IndexOf(),
    - -HasTable // key value pair
    - -- item.GetType().Name == DictionaryEntry
    - -SortedList
    - -Queue  // FIFO
    - --push(),pop(),peek()
    - --getEnumerator()
    - -Stack  // LIFO
    - --Enqueue(Object) == stackdeki push()
    - --Dequeue() == stack-deki pop()
    - --Peek()

# Week05-Day02 11/04/21

### Topics
    - C# Strings
    - -String as char Array
    - -String Concatenation
    - -Null vs Empty 
    - -IsNullOrEmpty, IsNullOrWhiteSpace
    - -ArraySegment
    - -StringSegment
    - -StringBuilder class
    - Methods
    - -Create a Method, Call a Method
    - -C# Method Parameters ( Parameters and Arguments ) When a parameter is passed to the method, it is called an argument.
    - - Return values return keyword.
    - - params , ref , out


### Resources
- [Methods (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods)
- [Strings (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/)
- [C# 9 simple type pattern](https://gist.github.com/AnthonyGiretti/56fbba3afefaea2356097e682f73ad23)


### Tasks
   - [Week5.Tasks](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/ConsoleApps/Week5/Week5.Tasks/Program.cs)
   - String haqqinda arasdirma edin.
   - Method haqqinda arasdirma edin.
   - Kecen hefte verilen tasklari yeniden analiz edin method-lari tetbiq etmeye calisin
   
   
# Week06-Day01 24/04/21

### Topics
    - What is OOP?
    - Classes and Objects
    - - Class members
    - - -Field
    - - -Property
    - - - -Full Property
    - - - -Prop
    - - - -Auto Property Initializers (C# 6.0)
    - - - -C# 7.2 Ref ReadOnly Returns
    - - - -Computed Properties
    - - - -Expression-Bodied Property
    - - -Method
    - - -Indexer
    - -Nested Type
    - -Summary
    - -this keyword
    -  Object Concepts
    -  Target-Typed New Expressions  C# 9.0
    -  Reference - object reference relationship
    -  Special Class members
    - -Constructor method - ctor
    - -Deconstructor method
    - -Static constructor method
    - -Deconstruct method
    - Encapsulation
    - - with properties
    - - with methods

# Week06-Day02 25/04/21

### Topics
    - What is OOP?
    - Classes and Objects
    - - Class members
    - - -Field
    - - -Property
    - - - -Full Property
    - - - -Prop
    - - - -Auto Property Initializers (C# 6.0)
    - - - -C# 7.2 Ref ReadOnly Returns
    - - - -Computed Properties
    - - - -Expression-Bodied Property
    - - -Method
    - - -Indexer
    - -Nested Type
    - -Summary
    - -this keyword
    -  Object Concepts
    -  Target-Typed New Expressions  C# 9.0
    -  Reference - object reference relationship
    -  Special Class members
    - -Constructor method - ctor
    - -Deconstructor method
    - -Static constructor method
    - -Deconstruct method
    - Encapsulation
    - - with properties
    - - with methods

### Tasks
   - [Week6 Tasks](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/ConsoleApps/Week6/Week6.Tasks/Program.cs)
   - Kecilen movzulari ciddi sekilde tekrar edin.


# Week07-Day01 01/05/21

### Topics
    - C# 2.0 Static (static member elements)
    - - Static class
    - - Static Field
    - - Static Method
    - - Static Constructor
    - - RAM  : Static area
    - - C# 6.0 Static using directives
    - Const
    - Readonly
    - Inner Type
    - Inheritance
    - - Object class
    - - Base class, Derived class
    - - Boxing/ UnBoxing
    - - Base keyword
    - - Sealed keyword
    - - Access Modifier : Protected
    - - - Base class ctor
    - - - Base vs This keyword
    - - Name Hiding


# Week07-Day02 02/05/21

### Topics
    - C# Polymorphism
    - - Polymorphism and Overriding Methods
    - - - virtual keyword
    - - - base keyword
    - - - this vs base 
    - - - override keyword
    - - - virtual member elements : property, method
    -  - Polymorphism and Overloading Methods
    -  - Overriding (run time) vs Overloading(compile time)
    - C# Abstraction
    - - Abstract class
    - - - Abstract class members
    - - - abstract vs virtual
    - - - abstract vs sealed
    - C# Interface
    - - Speacialities
    - - C# 8.0 Default Implementations

   ### Tasks
   - [Week7 Tasks](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/ConsoleApps/Week7/Week7.Tasks/Program.cs)

# Week08-Day01 08/05/21

### Topics
    - Partial Class
    - OOP Enum
    - - Enum : Inheritance
    - - Conversions
    - - Enum naming conventions
    - - Converts int to enum values : ToObject()
    - - Convert a string to an enum : Parse()
    - - Enum.GetNames()
    - - Enum.GetValues()
    - - Enum.IsDefined()
    - - Enum in a Switch Statement
    - - How to enumerate an enum : foreach
    - Generic Collections
    - - Non Generic Collections vs Generic Collections
    - - Type Safety c# 1.0 with methods
    - - Type Safety c# 1.0 with methods
    - - List<T>
    - - - List<T> vs ArrayList
    - - - Add()
    - - - AddRange()
    - - - Insert()
    - - - Remove()
    - - - RemoveAll()
    - - - RemoveAt()
    - - - Any()
    - - - Sort()
    - - - Max()
    - - - Min()
    - - Dictionary<K,T>
    - - - Dictionary<K,T> vs Hastable
    - - - Add()

# Week08-Day02 09/05/21

### Topics
    - Generic .Net 2.0
    - - Why we need generics in C#?
    - - What are Generics in C#?
    - - Advantages of Generics in C#.
    - - How to implement Generics in C#?
    - - How to use Generics with class and its members?
    - - - Generic Class
    - - - Generic Methods
    - - - Generic Type Parameters
    - - - Generic Interface
    - - Generic Constraint
    - - - where T : struct          T value type olmalidir.
    - - - where T : class           T reference type olmalidir.
    - - - where T : new()           T default ctor parametrsiz.
    - - - where T : class_name      T inheritance alimis olmalidir.
    - - - where T : interface_name  T implement edilmis olmalidir.
    - - Generic : Inheritance
    - - - Open-constructed generic
    - - - Closed-constructed generic
    - - - Closed-constructed generic Vs Open-constructed generic : Inheritance
    - - Generic : CLR support
    - - Generic Repository Intro
    - WindowsFormsApp
    - - WindowsFormsApp Intro
    - - ToolBox window
    - - Properties window
    - - - Event
    - - - Program.cs : The main entry point for the application. Application.Run()
    - - - Program.cs : The main entry point for the application. Application.Run()
    - - - Inheritance from : Form class , InitializeComponent()
    - - - Data Tranfer between forms
    - - - TextBox,Label,RichTextBox,Button,MessageBox() and other
### Tasks
   - 8 heftenin yekunu olaraq ilk taskiniz butun kecilenleri tekrarlamaq olacaq , novbeti gorusde etafli sual cavab olacaq hami hazir gelsin.
   -[week 8 tasks](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/WindowsFormsApps/Tasks/week8Tasks.txt.txt)


# Week09-Day01 29/05/21
### Topics
    - Checking and improving the homework of the past week
    - - Task: 1. new customer addition form
    - - Task: 2. Book Stock
    - - Task: 3. calculation of amount payable
    - - Task: 4. Calculation of poolL volume an filling time
    - - Task: 5. Pizza order system
    - Questions and answers for all 8-week lessons
    - Windows Form Applications
    - - Todo App
    - - - About the app : Any user should be able to create todo after login,
                          to-do has title, short description, description, importance level, status and date created,
                          created todos should be listed,
                          after the new todo is created, the system should ask the user whether to continue.
    - - - Folder structure
    ------------------------ - - About abstract and concret
    -----------------------
    -----------------------                     ---abstract
    ------------------------ - - DataAccess  >  |
    -----------------------                     ---concret
    -----------------------
    -----------------------                     ---abstract
    ------------------------ - - Business    >  |
    -----------------------                     --concret
    -----------------------
    -----------------------                     ---abstract
    ------------------------ - - Entities    >  |
    -----------------------                     --concret  

# Week09-Day02 30/05/21
### Topics
    - Todo App Completion of the application made in the previous lesson
### Tasks
    - Ilk tapsiriginiz dersde hazirladigimiz todo app-in cari veziyyetine qeder oz ferdi reponuzda
      eyni app-i hazirlamalisiz. Yeni todo formunda Importance level Statusla oxsar veziyyetde enum ile yazilmalidir.
      GetAll formunda operations hissesi Status enum-daki Statuslarla eyni olmalidir olmayan statuslari elave edin ve buttonlardan
      her hansisa birine click eden zaman cedvelde data olub olmamasi ile bagli istifadeciye melumat verin ve dialog penceresinden
      yeni todo elave etmek isteyirsinizmi sual vererek yonlendirin. GetAll Form da datagrid-in AutoSizeColumns ozelliyinden istifade edin,
      hemcinin cedvelde sutunlarin basliqlari meselen ImportanceLevel yox Importance level seklinde yazilmalidir, bunun ucun cedvelde gosterilen
      entity-nin property-lerinin uzerinde DisplayName atributundan istifade ede bilersiniz, cedvelin asagisinda labelda cedvelde olan row sayini gosterin.


# Week10-Day01 05/06/21
### Topics
    - SystemIO 
    - - Console App: Directory operations
    - - - CreateDirectory : DirectoryInfo
    - - - Exists : bool
    - - - Delete
    - - - Move
    - - Console App:File operations
    - - - Create : FileStream ,fileStream.Close
    - - - Exists : bool
    - - - Delete
    - - - Move
    - - - Copy
    - - - AppendAllText
    - - - ReadAllText
    - - WinFormsApp : SystemIOExampleAPP : save listed workers to text file
    - - - Nuget package : Installing the FakeData library
    - - - GetAll() : employers
    - - - SaveData() : save employer info to text file
    
# Week10-Day02 06/06/21
### Topics
    - SystemIO
    - - Tools
    - - - OpenFileDialog
    - - - SaveFileDialog
    - - - FileBrowserDialog
    - - - StreamWriter : Create text document form
    - - - StreamReader : Read text document form
    - - - Save data to text document form
    - Exception Handling 
    - -  try catch 
    - -  multiple catch blocks : FormatException
    - -  finally block
    - -  Custom Exception 
    - -  throw keyword
    
### Tasks
   - SystemIO namespace, FileStream, StreamWriter, StreamReader arashdirilmasi.
   - Exception Handling haqqinda arashdirma
   - [week 10 tasks](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/WindowsFormsApps/Tasks/week10.text)


# Week11-Day01 03/07/21
### Topics
    - Delegates (C# Programming Guide)
    - - -Declare a delegate
    - - -Set a target method
    - - -Invoke a delegate
    - - -Delegate Syntax
    - - -Passing Delegate as a Parameter
    - - -Multicast Delegate
    - - -Generic Delegate
    - -Func Delegate
    - -Action Delegate
    - -Predicate Delegate
    - -Anonymous Method
    
    
# Week11-Day02 04/07/21
### Topics
    - What is LINQ? LINQ (Language Integrated Query)
    - Why LINQ?
    - Use System.Linq namespace to use LINQ
    - LINQ Query Syntax
    - LINQ Method Syntax
    - Using delegates in query operations
    - - Where with Func delegate
    - - FindAll with Predicate delegate
    - - Foreach with Action delegate
    - Standard Query Operators
    - - Filtering Operator - Where
    - - Sorting Operators: OrderBy & OrderByDescending
    - - Sorting Operators: ThenBy & ThenByDescending
    - - Projection Operators: Select, SelectMany
    - - Quantifier Operator: Contains
    - - Aggregation Operator: Count

### Tasks
   - What is LINQ?.
   - Why LINQ?
   - [week 11 tasks](https://github.com/PragmatechEducation/CSharp_02/blob/main/WindowsFormsApps/Tasks/week10.text)

# Week12  21/08/21
### Topics
    - SQL
    - - Introduction to SQL
    - - Syntax
    - - Select
    - - Distinct
    - - As
    - - Top
    - - Where, and, or 
    - - Between 
    - - Like 
    - - In, not in 
    - - Order by
    - - Group by, having
    - - Where vs having
    - - Inner join
    - - Left join
    - - Right join
    - - Full join
### Resources
- [.sql file ](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/SQL/week12/week12.sql)

### Tasks
   - https://www.w3schools.com/sql/default.asp
   - [week 12 task](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/SQL/week12/week12Task.txt)

# Week13  29/08/21
### Topics
    - SQL
    - - CREATE,DROP,BACKUP DATABASE
    - - CREATE,DROP,ALTER TABLE
    - - INSERT,UPDATE,DELETE  STATEMENTS
    - - Constraints
    - - - NOT NULL
    - - - UNIQUE
    - - - PRIMARY KEY
    - - - FOREIGN KEY
    - - - CHECK
    - - - DEFAULT
    - - - AUTO INCREMENT
    - - Stored Procedures
    - - Normalization 1`s form
    - - One to many Relation
    - - Subquery
    - - Getdate()

### Tasks
   - [week 13 task](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/SQL/week13/week13Tasks.txt)
   - [SQL Views](https://www.w3schools.com/sql/sql_view.asp)
   - [SQL Functions](https://www.tutorialsteacher.com/sql/avg-function)
   - - - linkde gosterilen functionlarin her birine uc numune yazin.


# Week14  04/09/21
### Topics
    - SQL
    - - Views
    - - Declare Variables
    - - - Declare more than one variable
    - - - Declare a variable with an initial value
    - - - Declare more than one variable with an initial value
    - - Conditions
    - - - if else
    - - - case when
    - - Loop : while
    - - Temp table
    - - - Local temp table
    - - - Global temp table
    - - Try catch
    - - User defined functions
    - - - scalar-valued
    - - - table-valued
    - - - - table-valued : query
    - - - - table-valued  : variable table
    - - Triggers : insert | update | delete
    - - - For
    - - - After
    - - - Inserted
    - - - Deleted
    - - Design of database tables : Techizat 

### Tasks
   - Design of database tables : Techizat
     Record-da izah edilenlere uygun Techizat modulu ucun db ve cedvelllerin dizayn edilmesi.
     Cedveller sql de hazir vasitelerden istifade edilmeden tek tek yazilmalidir.
   - [week 14 task](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/SQL/week14/week14Tasks.txt)
   - [sql_server/union](https://www.techonthenet.com/sql_server/union.php)
   - [learn-sql-types-of-relations](https://www.sqlshack.com/learn-sql-types-of-relations/)


# Week15  11/09/21
### Topics
    - System.XML
    - - What is xml?
    - - Using the XmlTextWriter class
    - - Using the XmlTextReader class
    - Linq to Xml
    - - XML file creation processes
    - - XML data in List<T> Collection save
    - - Reading XML Files
    - - RSS Reading Application : WindowsFormsApps/Projects
    - Json
    - - What is json?
    - - Write json data
    - - Reading json data
    - Csv
    - - What is csv?

### Tasks
   - [week 15 task](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/ConsoleApps/week15/tasks/week15Tasks.txt)

# Week16  03/10/21
### Topics
    - Reflection
    - - LoadFile
    - - GetTypes
    - - - GetConstructors,GetMethods,GetProperties
    - - Late Binding
    - - - Activator.CreateInstance
    - - - methodInfo.Invoke
    - - Reflection Example : 'creation of json files linked to entities in phonebook app'.
### Tasks
   - [week 15 task](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/ConsoleApps/week15/tasks/week15Tasks.txt)


# Week17  10/10/21
### Topics
    - Phonebook application
    - - Create,Update,Delete
    - - Get All Contacts
    - - Export : CSV,JSON, XML
    - - v2 Reflection Example : 'creation of json files linked to entities in phonebook app'.
### Tasks
   - [week 17 task](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/ConsoleApps/week15/tasks/week15Tasks.txt)
   - Reflection
   - SOLID principles
 
 
# Week18  17/10/21
### Topics
    - SOLID principles
    - ADO.NET Overview 
    - How to Connect to a Database using ADO.NET 
    - - ADO.NET data provider : SqlClient (System.Data.SqlClient)
    - - SqlCommand Class
    - - - ExecuteNonQuery
    - - - ExecuteScalar
    - - SqlParameter Class
    - - SqlConnection Class
    - - - Connection string
    - - SqlDataReader Class
    - Changing database with ado.net for phone book app

### Resources
   - [Basics of ADO.NET](https://www.c-sharpcorner.com/UploadFile/18fc30/understanding-the-basics-of-ado-net/)
   - [ADO.NET code examples](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-code-examples)
   - [ADO.NET Introduction](https://www.javatpoint.com/ado-net-introduction)
   - [ADO.NET Introduction](https://dotnettutorials.net/lesson/what-is-ado-net/)



# Week19  24/10/21
### Topics
    - Introduction to ASP.NET Core
    - - Project Creation and File Structure (MVC)
    - - Program.cs
    - - Startup.cs
    - - - Service Container
    - - - PipeLine - middleware
    - - appsettings.json
    - - Properties
        -launchsettings.json
    - - Dependencies

### Resources
- [Choose an ASP.NET Core web UI](https://docs.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-5.0)
- [Introduction to ASP.NET Core Framework](https://dotnettutorials.net/lesson/introduction-to-asp-net-core/)
- [ASP.NET Core Tutorial](https://www.tutorialspoint.com/asp.net_core/index.htm)

# Week20  31/10/21
### Topics
    - Controller : Action Types
    - - - IActionResult
    - - - ActionResult
    - - - ViewResult
    - - - PartialViewResult
    - - - JsonResult
    - - - EmptyResult
    - - - ContentResult
    - - - ContentResult
    - - NonAction & NonController Attribute
    - Controller : Scaffolding
    - Controller <--> View Data Migration
    - - - ViewData
    - - - ViewBag
    - - - TemData
    - - - Tuple
    - - - ViewModel
    - Razor View
    - - Create View : Scaffolding
    - - operator : @
    - - if , ternary operator
    - - loop
    - - scope
              

### Resources
- [first-mvc-app/start-mvc](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio)
- [model-binding](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-5.0)




# Week21  07/11/21
### Topics
        * Heplers
            -UrlHelper
                - Action
                - ActionLink
                - Content
                - RouteUrl
                - prop: ActionContext
            -HtmlHelper
                methods:
                - Html.Partial
                - Html.RenderPartial
                - Html.ActionLink
                - Html Form
                    @Html.BeginForm()
                    @Html.CheckBox("checkBox")
                    @Html.TextBox("textBox")
                    @Html.Display("display")
                    @Html.Password("password")
                    @Html.TextArea("area")
                    @Html.ValidationMessage("validationMessage")
                properties:
                - ViewContext
                - TemData
                - ViewData
                - ViewBag
            -TagHelper
                
                @addTagHelper * ,Microsoft.AspNetCore.MVC.TagHelpers
                -asp-action
                -asp-controller
                -asp-for
                -asp-append-version="true"
                -partial
            
        *Model Binding
               -Form
               -QueryString
                   Request.QueryString
                   Request.Query
               -Route
                   Request.RouteValues
                   Tag Helper : asp-route
               -Header
                   Request.Headers
               -Ajax

### Resources
-[tag helpers](https://dotnettutorials.net/lesson/tag-helpers-in-asp-net-core-mvc/)
<br>
-[html helpers](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.htmlhelper?view=aspnetcore-6.0)
<br>
-[custom html helpers](https://www.youtube.com/watch?v=69k9sVVs1WU&list=PLQVXoXFVVtp33KHoTkWklAo72l5bcjPVL&index=21)
<br>
-[custom tag helpers](https://www.youtube.com/watch?v=I08ukyY5zLk&list=PLQVXoXFVVtp33KHoTkWklAo72l5bcjPVL&index=23)
<br>
-[model binding](https://www.yogihosting.com/aspnet-core-model-binding/)
<br>



# Week22  14/11/21
### Topics
    - Blog application : 
      -Project structure . Developing a Project with N-Tier Architecture
          * Data
          * Entities
          * Services
          * Shared
          * Web UI MVC (Asp.Net Core MVC)
      * Shared
         - Data 
            - Generic Repository Design Pattern
              * IEntityRepository<T>
                  - GetAllAsync
                  - GetAsync
                  - AddAsync
                  - UpdateAsync
                  - DeleteAsync
                  - AnyAsync
                  - CountAsync
                  - Entities
              * EfRepository<TEntity>
                  - DbContext
                  - DbSet<T>
                  - Implementation of IEntityRepository<TEntity>
              * install Microsoft.EntityFrameworkCore 
         - Entities
            - EntityBase abstract
            - IEntity interface
         - Extensions 
            - PasswordHasher : HashPassword Extension method 
      * Entities
          * User,
          * Role,
          * Post,
          * Category,
          * Comment


### Resources
-[What is an N-tier architecture?](https://docs.microsoft.com/en-us/learn/modules/n-tier-architecture/2-what-is-n-tier-architecture)
<br>
-[Entity Framework Core](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)
<br>
-[Extension Methods (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
<br>
-[Generic Repository Pattern in C#](https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/)
<br>
-[Asynchronous programming](https://docs.microsoft.com/en-us/dotnet/csharp/async)
<br>
-[Async and Await In C#](https://www.c-sharpcorner.com/article/async-and-await-in-c-sharp/)
<br>
-[Asenkron (Asynchronous) Programlama Nedir?](https://atarikguney.medium.com/asenkron-asynchronous-programlama-nedir-296230121f9d)



# Week23  05/12/21
### Topics
    - Asynchronous Programming   
        - Process
        - Thread
        - Process vs Thread
        - Paralellism
        - Concurrency
        - User Thread , Kernel Thread
    - Blog application :
        - 3. `Data`
                * Abstract : Repositories
                    * IUserRepository,
                    * IRoleRepository,
                    * IPostRepository,
                    * ICategoryRepository,
                    * ICommentRepository
  
                * Concrete : Repositories
                  * UserRepository,
                  * RoleRepository,
                  * PostRepository,
                  * CategoryRepository,
                  * CommentRepository

                * DbContext
                  * install Microsoft.EntityFrameworkCore
                  * install Microsoft.EntityFrameworkCore.SqlServer
                  * install Microsoft.EntityFrameworkCore.Design
                  * BlogContext
                    * DbSet
                    * override OnConfiguring()
                      * connectionString: optionsBuilder.UseSqlServer(@"connectionString")
                    * override OnModelCreating()
                      * modelBuilder.ApplyConfiguration(new UserConfiguration());
    
                4. * `FluentApi - Mapping  `
                   * IEntityTypeConfiguration
                     * UserConfiguration,
                       * builder.HasData -> Seed
                     * RoleConfiguration,
                       * builder.HasData -> Seed
                     * PostConfiguration,
                       * builder.HasData -> Seed
                     * CategoryConfiguration,
                       * builder.HasData -> Seed
                     * CommentConfiguration
                       * builder.HasData -> Seed


                5. * UnitOfWork design pattern
                    * IUnitOfWork
                    * UnitOfWork
       
                6. * `EF CORE CLI` 
                   * Powershell : `dotnet tool install --global dotnet-ef --version 5.0.0-preview.7.20365.15`
                   * Powershell last version : `dotnet tool install --global dotnet-ef`
                   * 
                   * create initial migration 
                     * `dotnet ef migrations add InitialCreate`
                     * `dotnet ef database update`
                   * `Package Manager Console : visual studio` 
                   * install : `Microsoft.EntityFrameworkCore.Tools`
                   * 
                   * create initial migration 
                     * `Add-Migration InitialCreate`
                     * `Update-Database`
 
        7. * `Result` : Shared/Utilities/Results
             * IResult 
             * Result 
             * IDataResult<out T> 

        8.  * `Services `
             * Abstract 
               * ICategoryService
                 * GetAsync
                 * GetAllAsync
                 * GetAllByNonDeletedAsync
                 * AddAsync
                 * UpdateAsync
                 * DeleteAsync
                 * HardAsync
               * IPostService
                 * GetAsync
                 * GetAllAsync
                 * GetAllByNonDeletedAsync
                 * GetAllByNonDeletedAndActiveAsync
                 * GetAllByCategoryAsync
                 * AddAsync
                 * UpdateAsync
                 * DeleteAsync
                 * HardAsync
             * Concrete
               * CategoryManager
               * PostManager
     
        * `Shared` / Entities / Abstract
           * GetBaseDto 
        * `Entities`
          * Dtos : 
            * AddDto
            * UpdateDto
            * ListDto
            * DataAnnotations : using System.ComponentModel.DataAnnotations;
            * [Required(ErrorMessage = "{0 is required")]
            * [DisplayName("Category Name")]
            * [MaxLength(70,ErrorMessage = "{0} should not be larger than {1} characters. ")]
            * [MinLength(3,ErrorMessage = "{0} must not be less than {1} characters.")]
            * [DisplayFormat(ApplyFormatInEditMode = true)]
            * [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy}")]


### Tasks
    * `Services `
     * Abstract
       * IPostService
         * GetAsync
         * GetAllAsync
         * GetAllByNonDeletedAsync
         * GetAllByNonDeletedAndActiveAsync
         * GetAllByCategoryAsync
         * AddAsync
         * UpdateAsync
         * DeleteAsync
         * HardAsync
     * Concrete
       * PostManager

### Resources
-[Entity Framework Core: DbContext](https://www.entityframeworktutorial.net/efcore/entity-framework-core-dbcontext.aspx)
<br>
-[First EF Core Console Application : migrations](https://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx)
<br>
-[One-to-Many Relationship Conventions in Entity Framework Core](https://www.entityframeworktutorial.net/efcore/one-to-many-conventions-entity-framework-core.aspx)
<br>
-[Configurations in Entity Framework Core](https://www.entityframeworktutorial.net/efcore/configuration-in-entity-framework-core.aspx)
<br>
-[Fluent API in Entity Framework Core](https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx)
<br>
[resource: Asynchronous Programming](https://github.com/parvizrovshanaliyev/CSharp02/blob/main/WindowsFormsApps/Week23/Readme.md)
<br>


# Week24  12/12/21
### Topics
    - Blog application :
        - 8.  * `Services `
                * Abstract 
                    * IPostService
                      * GetAsync
                      * GetAllAsync
                      * GetAllByNonDeletedAsync
                      * GetAllByNonDeletedAndActiveAsync
                      * GetAllByCategoryAsync
                      * AddAsync
                      * UpdateAsync
                      * DeleteAsync
                      * HardAsync
                    * Concrete
                      * PostManager
                * Dependencies
                  * install AutoMapper lib
                * AutoMapper / Profiles
                  * Profile
                    * CreateMap<>
                * Extensions
                  * ServiceCollectionExtensions
                    * method : LoadMyServices
                      *  services.AddDbContext<BlogContext>();
                      *  services.AddScoped<IUnitOfWork, UnitOfWork>();
                      *  services.AddScoped<ICategoryService, CategoryManager>();
                      *  services.AddScoped<IPostService, PostManager>();
                * Refactoring :
                    * IEntityRepository   
                      * return : Task<T> , add, update
                    * Services 
                      *  Task<IDataResult<TDto>> AddAsync
                      *  Task<IDataResult<TDto>> UpdateAsync
        - 9.  * `MVC`
                * add reference Service layer
                * `install  AutoMapper.Extensions.Microsoft.DependencyInjection`
                * `install  Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 5.0.12`
                * `Startup`
                  * `ContainerService`
                    * method: ConfigureService
                      * `services.LoadMyService();`
                      * `services.AddAutoMapper(typeof(CategoryProfile), typeof(PostProfile);`
                      * `services.AddControllersWithViews().AddRazorRuntimeCompilation();`
                  * `Pipeline`
                    * method : `Configure`
                      * app.UseEndpoints
                        * `endpoints.MapAreaControllerRoute(
                          name:"Admin",
                          areaName:"Admin",
                          pattern:"Admin/{controller}/{action=Index}/{id?}");`
                        * 
                        * endpoints.MapDefaultControllerRoute();
                      * `env.IsDevelopment()`
                        * `app.UseStatusCodePages();`
                      * `app.UseStaticFiles();` 
                      *
                * `Controllers `
                  * HomeController
                * `Views`
                  * Home
                    * Index.cshtml
                  * Shared
                    * Add Razor Layout : `_Layout.cshtml`
                  * Razor View Start : `_ViewStart.cshtml`
                    * `@{
                      Layout = "_Layout";
                      }`
                  * Razor View Import :` _ViewImports.cshtml`
                    * `@addTagHelper *,Microsoft.AspNetCore.Mvc.TagHelpers`
                * `Areas  / Admin`
                  * `Controllers` - attr : `[Area("Admin")]`
                    * HomeController
                    * CategoryController
                  * `Views`
                    * Home
                        * Index.cshtml
                    * Category
                        * Index.cshtml : 
                      
                          * template - datatable `https://datatables.net/`
                          * DataTables Custom Button: `https://datatables.net/extensions/buttons/examples/initialisation/custom.html`
                          * DataTables Bootstrap 4 Button: `https://datatables.net/extensions/buttons/examples/styling/bootstrap4.html`
                          * Custom Button Configurations : 
                          
                                        ` $(document).ready(function() {
                                                $('#entitiesDataTable').DataTable( {
                                                    dom:
                                                        "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
                                                        "<'row'<'col-sm-12'tr>>" +
                                                        "<'row'<'col-sm-5'i><'col-sm-7'p>>",
                                                            buttons: [
                                                                {
                                                                    text: 'Create',
                                                                    className:'btn',
                                                                    action: function ( e, dt, node, config ) {
                                                                        alert( 'Button create' );
                                                                    }
                                                                },
                                                                {
                                                                    text: 'Refresh',
                                                                    className:'btn btn-warning',
                                                                    action: function ( e, dt, node, config ) {
                                                                        alert( 'Button refresh' );
                                                                    }
                                                                }
                                                            ] 
                                                    } );
                                                } );`
                             scripts :
                              
                             `<script src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js" crossorigin="anonymous"></script>`
                             `<script src="https://cdn.datatables.net/1.11.3/js/dataTables.bootstrap4.min.js" crossorigin="anonymous"></script>`

                             styles :

                             `<link href="https://cdn.datatables.net/1.11.3/css/dataTables.bootstrap4.min.css" rel="stylesheet" crossorigin="anonymous"/>`
                             `<link href="https://cdn.datatables.net/buttons/2.1.0/css/buttons.bootstrap4.min.css" rel="stylesheet" crossorigin="anonymous"/>`
                          
                          * Error result : 
                    * `Shared`
                        * Add Razor Layout : _Layout.cshtml
                          * Let's Add Our Theme for Admin Area and Integrate it on Layout 
                          * [Template resource ](https://drive.google.com/file/d/1zIWs6U0uvrnpFVWXiOG8oXZmaI19HAk5/view?usp=sharing)
                          * Let's Add Required PartialView and RenderSection Sections on Admin Layout
                            * `@await Html.PartialAsync("_LayoutScriptsPartial");`
                            *` @await Html.PartialAsync("_LayoutStylesPartial");`
                            * `<partial name="_LayoutLeftSideBarNavPartial" />`
                              * NavBar Icons:
                                * Categories : `fas-fa-th-list`
                                * Posts : `fas fa-file-alt`
                                * Comments : `fas fa-comments`
                                * Roles : `fas fa-user-shield`
                                * Users : `fas fa-users`
                              
                                * [icons ](https://fontawesome.com/v5.15/icons?d=gallery&p=2&s=solid&m=free)
                              * [how-to-render-a-partial-view-in-asp-net-core](https://nitishkaushik.com/how-to-render-a-partial-view-in-asp-net-core/)
                            * `@await RenderSectionAsync("Scripts",false);`
                        * Razor View Start : _ViewStart.cshtml
                            * `@{
                              Layout = "_Layout";
                              }`
                        * Razor View Import : _ViewImports.cshtml
                            *` @addTagHelper *,Microsoft.AspNetCore.Mvc.TagHelpers`
                  * `wwwroot` : static files
                    * assets
                    * js
                    * css


        