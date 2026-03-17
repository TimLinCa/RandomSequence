using RandomNumberList;

namespace RandomNumberLIst.Test
{
    [TestClass]
    public class RandomSequenceTest
    {

        /// <summary>
        /// Test to validate Generate returns an array of 10000 elements
        /// </summary>
        [TestMethod]
        public void SequenceGeneratorTests_Generate10000Elements_ReturnsCorrectLength()
        {
            // Act
            int[] result = SequenceGenerator.Generate(1, 10000);
            // Assert
            Assert.AreEqual(10000, result.Length);
        }

        /// <summary>
        /// Test to validate Generate contains all values from 1 to 10000
        /// </summary>
        [TestMethod]
        public void SequenceGeneratorTests_Generate10000Elements_ContainsAllValues()
        {
            // Act
            int[] result = SequenceGenerator.Generate(1, 10000);
            var set = new HashSet<int>(result);
            // Assert
            for (int i = 1; i <= 10000; i++)
                Assert.IsTrue(set.Contains(i), $"Missing value: {i}");
        }

        /// <summary>
        /// Test to validate Generate produces no duplicate values
        /// </summary>
        [TestMethod]
        public void SequenceGeneratorTests_Generate10000Elements_NoDuplicates()
        {
            // Act
            int[] result = SequenceGenerator.Generate(1, 10000);
            int distinctCount = result.Distinct().Count();
            // Assert
            Assert.AreEqual(10000, distinctCount, "Duplicate values detected.");
        }

        /// <summary>
        /// Test to validate Generate produces different orderings on two consecutive runs
        /// </summary>
        [TestMethod]
        public void SequenceGeneratorTests_TwoConsecutiveRuns_ProduceDifferentOrderings()
        {
            // Act
            int[] first = SequenceGenerator.Generate(1, 10000);
            int[] second = SequenceGenerator.Generate(1, 10000);
            // Assert
            Assert.IsFalse(first.SequenceEqual(second),
                "Two consecutive runs produced identical orderings");
        }

        /// <summary>
        /// Test to validate Generate result is not sorted in ascending order
        /// </summary>
        [TestMethod]
        public void SequenceGeneratorTests_Generate10000Elements_IsNotSortedAscending()
        {
            // Act
            int[] result = SequenceGenerator.Generate(1, 10000);
            bool sorted = result.SequenceEqual(result.OrderBy(x => x));
            // Assert
            Assert.IsFalse(sorted, "Sequence appears to be sorted (not shuffled).");
        }

        /// <summary>
        /// Test to validate Generate returns an array of one element when min equals max
        /// </summary>
        [TestMethod]
        public void SequenceGeneratorTests_SingleElement_ReturnsArrayOfOne()
        {
            // Act
            int[] result = SequenceGenerator.Generate(5, 5);
            // Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(5, result[0]);
        }

        /// <summary>
        /// Test to validate Generate contains all values for a small range
        /// </summary>
        [TestMethod]
        public void SequenceGeneratorTests_SmallRange_ContainsAllValues()
        {
            // Act
            int[] result = SequenceGenerator.Generate(1, 10);
            // Assert
            CollectionAssert.AreEquivalent(Enumerable.Range(1, 10).ToArray(), result);
        }

        /// <summary>
        /// Test to validate Generate throws ArgumentException when min is greater than max
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SequenceGeneratorTests_MinGreaterThanMax_ThrowsArgumentException()
        {
            // Act
            SequenceGenerator.Generate(100, 1);
        }
    }
}