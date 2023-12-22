### Library Managment System
I consider Libro one of the most exciting projects I've ever worked on, as libraries and books are personally meaningful to me. I regard this project as the most significant one I've worked on so far. Although it is an API, it holds educational value even if it requires further development to function as a full-fledged program. Stemming from my belief in continuous learning and self-improvement, I consistently update it whenever I acquire new knowledge. Libro has been my best teacher in the last few months.
Libro was the final project of my internship at Foothill. Libro is a comprehensive Book Management System designed to facilitate the easy management and discovery of books in a library setting. The primary focus of this project is to design and implement the web APIs that will support the functionality of this application. These APIs will handle user registration and authentication, book transactions, patron profile management, book and author management, and more.

## **Main Features:**

### **User Registration and Authentication:**
Users should be able to register and log in to the system, and there should be different types of users (patrons, librarians, administrators) with different access levels.

### **Searching and Browsing Books:**

Users should be able to search for books by title, author, genre, and other relevant criteria, and browse all available books. Each book's information page should include details such as its title, author, publication date, genre, and availability status, **and the result should be paginated**

### **Book Transactions:**

Patrons should be able to reserve available books. Librarians should be able to check out books to patrons and accept returned books. The system should keep track of due dates for borrowed books and whether a book is overdue.

### **Patron Profiles:**

Patrons should be able to view their own profile, which includes their borrowing history and any current or overdue loans. Librarians and administrators should be able to view and edit patron profiles.

### **Book and Author Management:**

Librarians and administrators should be able to add, edit, or remove books and authors in the system. Administrators should be able to manage librarian accounts.

### **Software Architecture:**
Software architecture refers to the high-level structure of a software system. It encompasses the design decisions and patterns that shape the overall organization, behavior, and interaction of the system's components.
### **Layered Architecture:**
Layered architecture is an architectural style where a system is organized into multiple horizontal layers, each responsible for specific functionalities. Common layers include presentation, business logic, and data access.
## ***Traditional Database Centric Approach:***
The database as a central component in the system. In this approach the database is designed first and the application comes secondary. 
### **CRUD-Based Thinking:**
CRUD stands for Create, Read, Update, Delete - the basic operations that can be performed on data. CRUD-based thinking refers to a mindset where the primary focus is on these fundamental data manipulation operations.

![image](https://github.com/maryaamouri/Library.ManagmentSystem/assets/82655833/b31d53dc-bd39-420f-80b8-f74baa099417)

### **Results:**
This approach where very appropriate with features like Authors and Book. It Provide a **clear data Access layer** and good presentation with **thine controllers.** Finally, I had a very good results for Authors and Book CRUD feature. 
**What about more complex features which required more complex business logic?**

![image](https://github.com/maryaamouri/Library.ManagmentSystem/assets/82655833/fff68715-8fab-41bc-8561-a11cf9ba0dac)

### **Dissection:**
Thinking to system as CRUD-based. The burrowing service is considered as Create Book Transaction and update book to be reserved, while returning a book service is just updating the book to be reserved and updating the existing book transaction. This approach was not the best for these features. In addition of complexity there where a lack of validation roles. For example, you have to check that the returned book is the reserved and reserved by the same person. You have to check that that the book is available before reserving. I do not claim that these rules are impossible to implement using this system, as they are of course possible somehow. I finished with very thick services. Even though it may seem simple service but when writing the code there was a **huge miss in business logic** and a lot of **spaghetti code**.
Adding new features like cancel book reservation which also considered as Updating operation was not better. I add more roles like: the book reservation cannot canceled if not reserved and reserved by the same person. the book reservation cannot be canceled if already receipted. So, I have to new feature now, confirm reception by the librarian. These led me to add more roles.
The more I add new features the more complexities appeared. It was very strange and a bit unapplicable to have CRUD for a user profile, for example. The more realistic approach is to have the profile updated automatically when a user reserves a new book. This led me to cancel this part of the API and study more about database transactions as I will discuss below.
### **Critical Point:**
Recognizing limitations in the initial solution, I transitioned to the Clean Architecture, a more modern framework. This shift was not without challenges, requiring extensive learning through tutorials and articles. Simultaneously, Libro underwent reconstruction, aligning with the Clean Architecture principles.

## ***Domain-Centric:*** 
However, the lack of flexibility in my first solution makes me confused about the more complex requirements. I decided to try a more modern approach, The Clean Architecture. My first experience with clean architecture was hard. I did not understand the layers and the role of each. I watched many tutorials and read many articles. At the same time, I rebuilt Libro reflecting these new terms.

![Untitled Diagram drawio (10)](https://github.com/maryaamouri/Library.ManagmentSystem/assets/82655833/83992458-6837-4aac-8675-a69ecd8e9ace)

## **Clean Architecture**
Clean Architecture, proposed by Robert C. Martin, emphasizes the separation of concerns and maintaining a clear dependency hierarchy. It consists of concentric layers such as Entities, Use Cases, and Interfaces, with dependencies flowing inward.
**Clean Architecture: Focuses on essential and keep details for later.
-Essential: usecases and business logic.
-Detaild: Database, presentation.**63.

## **Domain-Centric**
A domain-centric approach focuses on modeling the core business domain and its logic. It often involves Domain-Driven Design (DDD) principles, emphasizing a deep understanding of the business domain and aligning software design with it.

## **Command Query Responsibility Segregation (CQRS)
CQRS is an architectural pattern that separates the concerns of handling commands (write operations) from queries (read operations). The primary goal is to improve scalability, performance, and maintainability by allowing each side of the system to be optimized independently based on its specific requirements.

## **Repositories**
Repositories provide a way to access and persist aggregates, abstracting data access logic. They facilitate the separation between domain logic and data access code, enabling the storage and retrieval of aggregates without exposing underlying storage details.

## **Domain Services**
Services are operations that don't naturally fit within the context of an entity or value object. They represent actions or processes in the domain and contribute to a more expressive and behavior-centric domain model.

## **Rich Domain Models**
Rich Domain Models refer to incorporating behavior and business logic directly into domain entities. Entities not only store data but encapsulate behavior expressed through methods, promoting encapsulation and ensuring consistency and integrity.

## **Domain Validation**
Domain Validation involves validating the consistency and correctness of data within the domain model, ensuring adherence to business rules. It facilitates maintaining data consistency and detecting issues early in the application flow.


## **Fluent Validation Pipeline Behavior**
In the context of Fluent Validation and ASP.NET Core, pipeline behavior refers to integrating validation into the request processing pipeline. Fluent Validation, a library for validation, is seamlessly integrated, offering automatic validation, detailed validation results, and customization options based on application requirements.

## **Database Partitions (Logical Partirion) **
Considering using different database contexts for Identity management provides isolation of Identity data. This separation allows for distinct security policies, compliance measures, and optimization based on the characteristics of Identity data.

![Untitled Diagram drawio (11)](https://github.com/maryaamouri/Library.ManagmentSystem/assets/82655833/97aec66b-b5f4-488c-984a-fcb905b7ce7f)

Database is logically separated, involving segregating the DbContext in a software system, using distinct contexts for identity-related data and other application data, despite utilizing the same underlying database. We have one DbContext for the identity-related schema and another for the core application schema, both pointing to the same physical database but different parts of it.
