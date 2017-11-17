function solution(arr) {
    for (let i = 0; i < arr.length; i++) {
        let student = JSON.parse(arr[i]);
        console.log("Name: " + student.name);
        console.log("Age: " + student.age);
        console.log("Date: " + student.date);
    }
}

solution([
    '{"name":"Gosho","age":10,"date":"19/06/2005"}',
    '{"name":"Tosho","age":11,"date":"04/04/2005"}',
]);
