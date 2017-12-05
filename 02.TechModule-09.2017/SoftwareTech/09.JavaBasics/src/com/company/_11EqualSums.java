package com.company;

import java.util.Arrays;
import java.util.Scanner;

public class _11EqualSums {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] array = Arrays.asList(
                scan.nextLine()
                        .split("[ ]+"))
                .stream()
                .mapToInt(Integer::parseInt)
                .toArray();

        int possition = 0;

        int leftIndex = 0;
        int rightIndex = array.length - 1;

        long leftSum = array[leftIndex];
        long rightSum = array[rightIndex];

        while (leftIndex != rightIndex)
        {
            if (leftSum <= rightSum)
            {
                leftIndex++;
                leftSum += array[leftIndex];
                possition = leftIndex;
            }
            else if (leftSum >= rightSum)
            {
                rightIndex--;
                rightSum += array[rightIndex];
            }
        }


        if (leftSum == rightSum)
        {
            System.out.println(possition);
        }
        else
        {
            System.out.println("no");
        }
    }
}
