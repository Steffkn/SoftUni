package com.company;

import java.util.Arrays;
import java.util.Scanner;

public class _22CircleIntersection {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        int[] circle1 = Arrays.asList(
                scan.nextLine()
                        .split("[ ]+"))
                .stream()
                .mapToInt(Integer::parseInt)
                .toArray();

        int[] circle2 = Arrays.asList(
                scan.nextLine()
                        .split("[ ]+"))
                .stream()
                .mapToInt(Integer::parseInt)
                .toArray();

        Circle c1 = new Circle(circle1[2], new Point(circle1[0], circle1[1]));
        Circle c2 = new Circle(circle2[2], new Point(circle2[0], circle2[1]));

        boolean intersecting = Intersect(c1, c2);
        if (intersecting) {
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }

    private static boolean Intersect(Circle c1, Circle c2) {
        double distance = Math.sqrt(c1.getCenter().getX() * c1.getCenter().getY() + c2.getCenter().getX() * c2.getCenter().getY());
        return distance <= c1.getRadius() + c2.getRadius();
    }
}

class Circle {
    private int radius;
    private Point center;

    public int getRadius() {
        return radius;
    }

    public void setRadius(int radius) {
        this.radius = radius;
    }

    public Point getCenter() {
        return center;
    }

    public void setCenter(Point center) {
        this.center = center;
    }

    public Circle(int radius, Point center) {
        this.radius = radius;
        this.center = center;
    }
}

class Point {
    private int x;
    private int y;

    public int getX() {
        return x;
    }

    public void setX(int x) {
        this.x = x;
    }

    public int getY() {
        return y;
    }

    public void setY(int y) {
        this.y = y;
    }

    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
}