# Practical_task
The assignment was completed according to the specifications provided.

First assignment: C# 
-----------------------------------
> Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.

For the convenience of developers, the library is provided with unit-tests that allow you to quickly check its correctness of execution.


Second assignment: SQL
-----------------------------------
> В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

The solution to this problem is as follows:
```sql
SELECT
    Products.ProductName,
    Categories.CategoryName
FROM
    Products
LEFT JOIN
    ProductCategories ON Products.ProductID = ProductCategories.ProductID
LEFT JOIN
    Categories ON ProductCategories.CategoryID = Categories.CategoryID
ORDER BY
    Products.ProductName,
    Categories.CategoryName;
```
Explanation:
   - LEFT JOIN ProductCategories links products to their categories, but includes all products even if they don't have corresponding categories.
   - LEFT JOIN Categories adds the name of the category.
     
Thus, the final query returns all "Product Name - Category Name" pairs and even includes products without categories (a pair with an empty value for the category name).
