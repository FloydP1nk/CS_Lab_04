namespace Lab_04_01;

public class MyMatrix
{
     private int _rows;
    private int _columns;
    private int[,] _matrix;
    private Random random;

    public MyMatrix(int rows, int columns, int minVal, int maxVal)
    {
        _rows = rows;
        _columns = columns;
        _matrix = new int[rows, columns];
        random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                _matrix[i, j] = random.Next(minVal, maxVal + 1);
            }
        }
    }

    public int this[int row, int column]
    {
        get { return _matrix[row, column]; }
        set { _matrix[row, column] = value; }
    }

    public static MyMatrix operator *(int scalar, MyMatrix matrix)
    {
        for (int i = 0; i < matrix._rows; i++)
        {
            for (int j = 0; j < matrix._columns; j++)
            {
                matrix[i, j] *= scalar;
            }
        }

        return matrix;
    }

    public static MyMatrix operator /(int scalar, MyMatrix matrix)
    {
        for (int i = 0; i < matrix._rows; i++)
        {
            for (int j = 0; j < matrix._columns; j++)
            {
                matrix[i, j] /= scalar;
            }
        }

        return matrix;
    }

    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1._rows != matrix2._rows || matrix1._columns != matrix2._columns)
        {
            throw new ArgumentException("Matrices must be the same size");
        }

        MyMatrix result = new MyMatrix(matrix1._rows, matrix1._columns, 0, 0);

        for (int i = 0; i < result._rows; i++)
        {
            for (int j = 0; j < result._columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1._rows != matrix2._rows || matrix1._columns != matrix2._columns)
        {
            throw new ArgumentException("Matrices must be the same size");
        }

        MyMatrix result = new MyMatrix(matrix1._rows, matrix1._columns, 0, 0);

        for (int i = 0; i < result._rows; i++)
        {
            for (int j = 0; j < result._columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1._columns != matrix2._rows)
        {
            throw new ArgumentException(
                "Number of _columns in first _matrix must be equal to number of rows in second _matrix.");
        }

        MyMatrix result = new MyMatrix(matrix1._rows, matrix2._columns, 0, 0);
        for (int i = 0; i < result._rows; i++)
        {
            for (int j = 0; j < result._columns; j++)
            {
                for (int k = 0; k < matrix1._columns; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }
}