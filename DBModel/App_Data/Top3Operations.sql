Select Top 3 OperationName, Count(*) as OperationCount 
                    From OperationResult 
                    Group By OperationName 
                    Order By OperationCount DESC