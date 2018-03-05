using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace CodingExercises
{
    /// <summary>
    /// This was converted from Java to C# from earliest OOP Class.
    /// </summary>
    class UniArrayExercises
    {
        /**
    * This method counts and returns how many times the target
    * string occurs in the array.  For this method,
    * two strings are considered the same if they contain
    * exactly the same text. 
    * <p>
    * 
    * <p><b>The TA will help you write this method in lab.</b>
    * 
    * @param values   An array of String references
    * @param target   A target String object
    * @return   The number of strings in the array that equal the target
    * @throws NullPointerException   If values is null
    */
        public static int Count(String[] values, String target)
        {
            int targetCount = 0;
            for (int position = 0; position < values.Length; position++)
            {
                if (values[position] == target)
                {
                    targetCount++;
                }
            }
            return targetCount;
        }

        /**
         * This method sorts the elements in the data array
         * in descending order.  (The largest element will 
         * be placed in position 0.)
         * <p>
         * 
         * Note that this method does not have a return
         * type - the data array is sorted 'in place'.
         * <p>
         * 
         * <p><b>The TA will help you write this method in lab.</b>
         * 
         * @param data   The array to be sorted
         * @throws NullPointerException   If data is null
         */
        public static void Sort(int[] data)
        {
            //data[i];
            int max;
            int index;

            for (int i = 0; i < data.Length; i++)
            {
                max = data[i];
                index = i;

                for (int j = i; j < data.Length; j++)
                {
                    if (data[j] > max)
                    {
                        max = data[j];
                        index = j;
                    }
                }
                // Swap
                data[index] =
                data[i] = max;
            }
        }

        /**
         * This method examines the elements in the array and
         * replaces all occurrences of the original object 
         * with the replacement object.
         * <p>
         * 
         * For this method, two objects are considered equal
         * if they refer to the same object.  Note that either
         * the original object, the replacement object, or
         * any of the objects in the list may be null.
         * <p>
         * 
         * This method does not have a return
         * type - the list array is modified directly.
         * <p>
         * 
         * <p><b>You will write this method in lab.</b>
         * 
         * @param list   An array of Object references
         * @param original   The object to be replaced
         * @param replacement   The replacement object
         * @throws NullPointerException   If list is null
         */
        public static void Replace(Object[] list, Object original, Object replacement)
        {
            for (int position = 0; position < list.Length; position++)
            {
                if (list[position] == original)
                {
                    list[position] = replacement;
                }
            }
        }

        /**
         * This method creates and returns a new array that
         * contains all the colors stored in the original array,
         * except those colors that are equal to the target.  For this
         * method, two colors are equal if they represent the
         * same color.<p>
         * 
         * Note that target may be null, and pixels may contain
         * null elements.  Two null elements will be considered equal.
         * <p>
         * 
         * <p><b>You will write this method in lab.</b>
         * 
         * @param pixels   An array of Color references
         * @param target   The Color object to be removed
         * @throws NullPointerException   If pixels is null
         */
        public static Color[] Remove(Color[] pixels, Color target)
        {
            int notTarget = 0;
            for (int position = 0; position < pixels.Length; position++)
            {
                if (pixels[position] != target)
                {
                    notTarget++;
                }
            }

            Color[] withoutTarget = new Color[notTarget];

            int withoutTargetPosition = 0;
            for (int position = 0; position < pixels.Length; position++)
            {
                if (pixels[position] != target)
                {
                    withoutTarget[withoutTargetPosition] = pixels[position];
                    withoutTargetPosition++;
                }
            }
            return withoutTarget;
        }


        /**
         * This method computes and returns the area of several rectangular
         * regions.  For a rectangle i, width[i] specifies
         * the width of the rectangle, and height[i] specifies
         * the height of the rectangle.  A new array is created
         * (that is the same size as the width and height arrays)
         * and the area of each rectangle is computed and placed
         * in this array.  (Area of rectangle i would be stored
         * in the ith position in the array.)  The array is then returned.
         * <p>
         * 
         * This method assumes that the widths and heights are positive.
         * <p>
         * 
         * Note that width and height arrays must be the same size.
         * <p>
         * 
         * <p><b>You will write this method in lab.</b>
         * 
         * @param widths   An array of rectangle widths
         * @param heights  An array of rectangle heights
         * @return   An array of rectangle areas
         * @throws NullPointerException   If widths or heights is null
         * @throws ArrayIndexOutOfBoundsException   If widths or heights are not the same size
         */
        public static double[] ComputeAreas(double[] widths, double[] heights)
        {
            double[] rectangleAreas = new double[widths.Length];

            for (int position = 0; position < widths.Length; position++)
            {
                rectangleAreas[position] = widths[position] * heights[position];
            }
            return rectangleAreas;
        }

        /**
         * This method reverses 'in place' the elements in
         * the array.  Reversing is defined as moving the
         * elements in the array such that the first element
         * becomes the last element, the second element
         * becomes the second to last element, etc.
         * <p>
         * 
         * <p><b>You will write this method as part of programming assignment #7.</b>
         * 
         * @param symbols   An array that will be reversed.
         */
        public static void ReverseOrder(char[] symbols)
        {
            int leftIndex = 0;
            int rightIndex = symbols.Length - 1;

            // have a temp character keep the character of the left index before the swap, then swap left with right indexes,
            // and then set the right index to the temp character
            // once the left index is greater than right index, stop so that if the array is odd the middle character will be the same
            while (leftIndex < rightIndex)
            {
                char temp = symbols[leftIndex];
                symbols[leftIndex] = symbols[rightIndex];
                symbols[rightIndex] = temp;

                ++leftIndex;
                --rightIndex;
            }
        }

        /**
         * This method counts how many times each value appears 
         * in the ages list, and returns an array of these counts.
         * (If 16 occurs 12 times in the ages array, then 
         * the returned array will contain a twelve in the seventeenth
         * element of the array.)  This method assumes that age values 
         * will be non-negative and small.
         * <p>
         * 
         * The size of the returned list is determined by the maximum value
         * stored in the ages list.  The size of the returned list will be
         * one greater than the maximum value stored in the ages list.
         * <p>
         * 
         * <p><b>You will write this method as part of programming assignment #7.</b>
         * 
         * @param ages   A list ages
         * @return   An array of counts, each element corresponds to one age
         */
        public static int[] Histogram(int[] ages)
        {
            // The Max value of the ages array will be the histogram size if a one is added, because the zero has to be accounted for
            int histogramSize = 0;
            for (int position = 0; position < ages.Length; position++)
            {
                if (ages[position] > histogramSize)
                {
                    histogramSize = ages[position];
                }
            }
            histogramSize = histogramSize + 1;

            int[] histogram = new int[histogramSize]; //creates the histogram array   	

            // for each histogramPosition calculate the max value, count it, and turn it to negative one and then store the count in the histogram
            for (int histogramPosition = 0; histogramPosition < histogram.Length; histogramPosition++)
            {
                int maxCount = 0;
                int max = 0;

                // Find the maximum value in the ages array
                for (int position = 0; position < ages.Length; position++)
                {
                    if (ages[position] > max)
                    {
                        max = ages[position];
                    }
                }

                // Count the maximum values in the ages array and turn them to negative one.
                for (int position = 0; position < ages.Length; position++)
                {
                    if (ages[position] == max)
                    {
                        maxCount++;
                        ages[position] = -1; // Turn the max values in the ages array to -1, so that it will not be a max the second time through, but let 0 be a max
                    }
                }

                histogram[histogramPosition] = maxCount; // The max count of the current histogram position will be stored		   	 
            }

            // use the reverse order method code to count up from 0 instead of the max value in the histogram array
            int leftIndex = 0;
            int rightIndex = histogram.Length - 1;

            while (leftIndex < rightIndex)
            {
                int temp = histogram[leftIndex];
                histogram[leftIndex] = histogram[rightIndex];
                histogram[rightIndex] = temp;

                ++leftIndex;
                --rightIndex;
            }

            return histogram; // Return the histogram that counts 0's first, 1's second and so forth       
        }

        /**
         * This method creates and returns a new array that contains a list of the
         * unique File objects that occur in the files array.  For this method,
         * File objects are the same if they are equal using the .equals method.
         * <p>
         * 
         * The size of the returned list is determined by the number of unique
         * items in the original list.  The order of the items in the returned
         * list is unspecified.
         * <p>
         * 
         * The files array must not contain null.
         * <p>
         * 
         * <p><b>You will write this method as part of programming assignment #7.</b>
         * 
         * @param files   An array of File objects, possibly containing duplicates
         * @return   An array of unique File objects
         * @throws NullPointerException   If files is null or files contains null
         */
        //public static File[] GetUnique(File[] files)
        //{
        //    //Calculate the size of the new file array
        //    int size = files.Length;
        //    for (int position = 0; position < size; position++)
        //    {
        //        for (int alphaPosition = 0; alphaPosition < size; alphaPosition++)
        //        {
        //            if (files[position].Equals(files[alphaPosition]))
        //            {
        //                size--;
        //            }
        //        }
        //    }
        //    size++;

        //    //Create new file array
        //    File[] uniqueFiles = new File[size];

        //    // Turn the duplicates to null
        //    for (int position = 0; position < files.Length; position++)
        //    {
        //        for (int alphaPosition = position + 1; alphaPosition < files.Length; alphaPosition++)
        //        {
        //            if (files[position] != null && files[position].Equals(files[alphaPosition]))
        //            {
        //                files[alphaPosition] = null;
        //            }
        //        }
        //    }

        //    // Collect the originals that are not null
        //    for (int uniqueFilesPosition = 0; uniqueFilesPosition < uniqueFiles.Length; uniqueFilesPosition++)
        //    {
        //        for (int position = 0; position < files.Length; position++)
        //        {
        //            for (int alphaPosition = 0; alphaPosition < files.Length; alphaPosition++)
        //            {
        //                if (files[position] != null && files[position].Equals(files[alphaPosition]))
        //                {
        //                    uniqueFiles[uniqueFilesPosition] = files[alphaPosition];
        //                    uniqueFilesPosition++;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    //Return the array of uniqueFiles
        //    return uniqueFiles;

        //    // if(methodCompleted)
        //    //  me = happy;
        //}


        /**
         * This method finds and returns the smallest rectangle in the
         * array.  The smallest rectangle is defined as the one
         * with the smallest area.  If two rectangles have the same
         * smallest area, the one that occurs last in the array
         * is returned.
         * <p>
         * 
         * This method requires that the rectangles array 
         * must not contain null.
         * <p>
         * 
         * <p><b>You will write this method as part of programming assignment #7.</b>
         * 
         * @param rectangles   An array of rectangle objects
         * @return   The smallest rectangle in the array
         * @throws NullPointerException   If rectangles is null or rectangles contains null
         */
        public static Rectangle FindSmallest(Rectangle[] rectangles)
        {
            if (rectangles.Length == 0)
            {
                Rectangle none = new Rectangle();
                return none;
            }
            else
            {
                Rectangle smallest = rectangles[0]; // set the first smallest rectangle to the first rectangle in the array

                //Calculate the smallest area, the one with the smallest area will be the smallest rectangle
                double smallestArea = rectangles[0].Height * rectangles[0].Width;
                for (int position = 0; position < rectangles.Length; position++)
                {
                    double area = rectangles[position].Height * rectangles[position].Width;
                    if (area <= smallestArea) // use less than or equal to, so that the last one that occurs in the array is returned if it is equal to one before it.
                    {
                        smallestArea = area;
                        smallest = rectangles[position];
                    }
                }

                return smallest;
            }
        }
    }
}
