using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdwancedSaveSystem.SaveSystem
{
    [Serializable]
    public class ASSDictonary<T,T1>
    {
        private T[] tArray;
        private T1[] t1Array;
        private int count = 0;

        
        [NonSerialized]private T1 targetValue;
        [NonSerialized]private T targetKey;

        [NonSerialized]
        private Dictionary<T, T1> thisDictionary;

        
        public int Lenght
        {
            get { return count; }
        }

        public T[] Keys
        {
            get { return tArray; }

        }

        public T1[] Values
        {
            get { return t1Array; }
        }

        public ASSDictonary()
        {
        }

        public ASSDictonary(ASSDictonary<T,T1> dictonary)
        {
            tArray = dictonary.Keys;
            t1Array = dictonary.Values;
            count = dictonary.Lenght;
        }

        public ASSDictonary(T[] key,T1[] value,int lenght)
        {
            if (Equals(Equals(key,value),lenght))
            {
                tArray = key.ToArray();
                t1Array = value.ToArray();
                count = lenght;

            }
            else
            {
                new Exception("Arrays length and length is not equals");
            }
        }

        public void Add(T key, T1 value)
        {
            tArray[count] = key;
            t1Array[count] = value;
            count++;
            UpdateThisDictonary();
        }

        public T1 GetValue(T key)
        {
            for (int i = 0; i < count; i++)
            {
                if (tArray[i].Equals(key))
                {
                    targetValue = t1Array[i];
                    break;
                }
            }
            return targetValue;
        }

        public T GetKey(T1 value)
        {
            for (int i = 0; i < count; i++)
            {
                if (tArray[i].Equals(value))
                {
                    targetKey = tArray[i];
                    break;
                }
            }
            return targetKey;
        }

        public Dictionary<T, T1> ToDictionary()
        {
            Dictionary<T,T1> dic =  new Dictionary<T, T1>();

            for (int i = 0; i < count; i++)
            {
                dic.Add(tArray[i],t1Array[i]);
            }

            return dic;
        }

        public ASSDictonary<T,T1> ToASSDictonary()
        {
            return this;
        }

        private void UpdateThisDictonary()
        {
            thisDictionary = ToDictionary();
        }
    }
}
