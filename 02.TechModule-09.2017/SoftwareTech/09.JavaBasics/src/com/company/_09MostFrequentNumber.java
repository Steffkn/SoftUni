package com.company;

import java.util.*;

public class _09MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] numbers = Arrays.asList(
                scan.nextLine()
                        .split("[ ]+"))
                .stream()
                .mapToInt(Integer::parseInt)
                .toArray();
        Map<Integer, Integer> dict = new LinkedHashMap<>();

        for (int number : numbers) {
            if (!dict.containsKey(number)) {
                dict.put(number,1);
            }
            else {
                dict.put(number, dict.get(number) + 1);
            }
        }

        int maxValueInMap=(Collections.max(dict.values()));

            for (Map.Entry<Integer, Integer> entry : dict.entrySet()) {  // Itrate through hashmap
            if (entry.getValue() == maxValueInMap) {
                System.out.println(entry.getKey());     // Print the key with max value
                break;
            }
        }
    }
}
