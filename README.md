Sorting Hat Graphs
===================
This project is a C# MVC application that also provides a RESTful web protocol to sort lists based on the sort function chosen. The application also displays each step of the sort operation on the web page for the user.

Sort Application
-----------------
The following pages have been implemented. Visit the urls to perform a sort and see the step-by-step process of sorting the list :
```
/quicksort
```

Sort RESTful API
-----------------
The following urls have been implemented. Send a POST HTTP request with a list of integers to sort:
```
/quicksort
```
Example of using QuickSort on a List:
```
POST /api/quicksort HTTP/1.1
Host: localhost:53658
Content-Type: application/x-www-form-urlencoded
list=1&list=3&list=5&list=4&list=95&list=53&list=0&list=002
```

Postman
-----------------
The [Postman][postmanlink] is a useful program to send HTTP Requests to the web application.

[postmanlink]: https://www.getpostman.com/