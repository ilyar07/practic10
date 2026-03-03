using practic10;

namespace practic10.Test
{
    public class CheckerBoardPositionTes()
    {
        // Constructor
        [Theory]
        [InlineData(1, 1)]
        [InlineData(8, 8)]
        [InlineData(4, 7)]

        public void Constructor_ValidValues_CreateObject(byte x, byte y)
        {
            var obj = new CheckerBoardPosition(x, y);

            Assert.Equal(x, obj.X);
            Assert.Equal(y, obj.Y);

        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(100, 2)]
        [InlineData(2, 100)]
        public void Constructor_InValidValues_ArgumentOutOfRangeException(byte x, byte y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>  new CheckerBoardPosition(x, y));
        }


        // XLetter
        [Theory]
        [InlineData(1, 'A')]
        [InlineData(2, 'B')]
        [InlineData(3, 'C')]
        [InlineData(4, 'D')]
        [InlineData(5, 'E')]
        [InlineData(6, 'F')]
        [InlineData(7, 'G')]
        [InlineData(8, 'H')]
        public void XLetter_ValidValues_CorrectLetter(byte x, char letter) 
        {
            var obj = new CheckerBoardPosition(x, 1);

            Assert.Equal(letter, obj.XLetter);
        }


        // ToString()
        [Theory]
        [InlineData(1, 1, "A1" )]
        [InlineData(8, 8, "H8" )]
        [InlineData(4, 6, "D6" )]
        public void ToString_ValidValues_CorrectString(byte x, byte y, string s)
        {
            var obj = new CheckerBoardPosition(x, y);

            Assert.Equal(s, obj.ToString());
        }

        // Parse()
        [Theory]
        [InlineData("A1", 1, 1)]
        [InlineData("H8", 8, 8)]
        [InlineData("D4", 4, 4)]
        [InlineData("C7", 3, 7)]
        public void Parse_ValidValues_CorrectObject(string s, byte x, byte y)
        {
            var obj = CheckerBoardPosition.Parse(s, null);

            Assert.Equal(x, obj.X);
            Assert.Equal(y, obj.Y);
        }

        [Theory]
        [InlineData("fadafd")]
        [InlineData("11")]
        [InlineData("O0")]
        [InlineData("1412")]
        public void Parse_InValidValues_ThrowFormatException(string s)
        {
            Assert.Throws<FormatException>(() => CheckerBoardPosition.Parse(s, null));
        }

        [Fact]
        public void Parse_NullString_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => CheckerBoardPosition.Parse(null, null));
        }

        // TryParse()
        [Theory]
        [InlineData("A1", 1, 1)]
        [InlineData("H8", 8, 8)]
        [InlineData("D4", 4, 4)]
        [InlineData("C7", 3, 7)]
        public void TryParse_ValidValues_True(string s, byte x, byte y)
        {
            var res = CheckerBoardPosition.TryParse(s, null, out var obj);

            Assert.True(res);
            Assert.Equal(x, obj.X);
            Assert.Equal(y, obj.Y);
        }

        [Theory]
        [InlineData("B0")]
        [InlineData("J6")]
        [InlineData("asd")]
        [InlineData("pp")]
        [InlineData("A4 ")]
        [InlineData("")]
        [InlineData("A")]     
        [InlineData("A123")]  
        [InlineData("1A")]   
        [InlineData("AA")]    
        [InlineData("11")]
        public void TryParse_InvalidValues_False(string s)
        {
            var res = CheckerBoardPosition.TryParse(s, null, out var obj);

            Assert.False(res);
            Assert.Null(obj);
        }

        [Fact]
        public void TryParse_NullString_False() 
        {
            var res = CheckerBoardPosition.TryParse(null, null, out var obj);

            Assert.False(res);
            Assert.Null(obj);
        }

    }
}
