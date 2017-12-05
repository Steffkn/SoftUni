package com.company;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import static java.util.Collections.reverseOrder;

public class _24BookLibrary {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        Library lib = new Library("Library");
        DateTimeFormatter format = DateTimeFormatter.ofPattern("dd.MM.yyyy");

        int n = scan.nextInt();
        scan.nextLine();

        for (int i = 0; i < n; i++) {
            String[] input = scan.nextLine().split(" ");

            lib.addBook(new Book(
                    input[0],
                    input[1],
                    input[2],
                    LocalDate.parse(input[3], format),
                    input[4],
                    Double.parseDouble(input[5])
            ));
        }

        LinkedHashMap<String, Double> authors = new LinkedHashMap<>();

        for (Book book : lib.getBooks()) {
            if (!authors.containsKey(book.getAuthor())) {
                authors.put(book.getAuthor(), book.getPrice());
            } else {
                authors.put(book.getAuthor(), authors.get(book.getAuthor()) + book.getPrice());
            }
        }
        Map result = authors.entrySet().stream()
                .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue,
                        (oldValue, newValue) -> oldValue, LinkedHashMap::new));

        for (Object author : result.keySet()) {
            System.out.printf("%s -> %.2f%n",author, authors.get(author));
        }
    }
}

class Library {
    private String name;
    private ArrayList<Book> books;

    public Library(String name) {
        this.name = name;
        books = new ArrayList<>();
    }

    public ArrayList<Book> getBooks() {
        return books;
    }

    public void addBook(Book book) {
        this.books.add(book);
    }
}

class Book {
    private String title;
    private String author;
    private String publisher;
    private LocalDate releaseDate;
    private String ISBN;
    private double price;

    public Book(String title, String author, String publisher, LocalDate releaseDate, String ISBN, double price) {
        this.title = title;
        this.author = author;
        this.publisher = publisher;
        this.releaseDate = releaseDate;
        this.ISBN = ISBN;
        this.price = price;
    }

    public String getAuthor() {
        return author;
    }

    public double getPrice() {
        return price;
    }
}