-- Drop the table 'Products' in schema 'SchemaName'
IF EXISTS (
    SELECT *
        FROM sys.tables
    WHERE sys.tables.name = 'Products'
)
    DROP TABLE Products
GO