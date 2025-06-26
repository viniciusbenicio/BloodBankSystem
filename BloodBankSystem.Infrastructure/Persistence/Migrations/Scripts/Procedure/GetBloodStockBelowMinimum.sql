CREATE OR ALTER PROCEDURE GetBloodStockBelowMinimum 
(
    @BloodType NVARCHAR(3),
    @MinQuantity INT 
)
AS
BEGIN
    
    SELECT * FROM BloodStocks AS BS
	WHERE BS.BloodType = @BloodType and BS.QuantityML <= @MinQuantity
END
GO

// example de uso
EXEC GetBloodStockBelowMinimum 'A', 5000
