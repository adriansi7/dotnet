using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ex6
{
    class BitArray64 : IEnumerable<ulong>
    {
        private ulong Value;

        public BitArray64(ulong value = 0)
        {
            this.Value = value;
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
               yield return ((this.Value >> i) & 1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Indexer
        public ulong this[int index]
        {
            get
            {
                if (index >= 0 && index <= 63)
                {
                    // Check the bit at position index
                    return ((this.Value >> index) & 1);
                }
                else
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
            }
            set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException(String.Format("Value {0} is invalid!", value));
                }

                // Clear the bit at position index
                this.Value &= ~(1ul << index);
                // Set the bit at position index to value
                this.Value |= (1ul << index);
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 63; i >= 0; i--)
            {
                result.Append((this.Value >> i) & 1);
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            var otherBitArray = obj as BitArray64;

            if (otherBitArray != null)
            {
                for (int i = 0; i <= 63; i++)
                {
                    if (this[i] != otherBitArray[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(BitArray64 a, BitArray64 b)
        {
            return BitArray64.Equals(a, b);
        }

        public static bool operator !=(BitArray64 a, BitArray64 b)
        {
            return !BitArray64.Equals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.Value.GetHashCode();
        }
    }
}
