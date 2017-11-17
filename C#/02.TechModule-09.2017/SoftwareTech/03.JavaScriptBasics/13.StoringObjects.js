function solution(arr) {
    let objs = {};
    for(let i = 0; i< arr.length; i++){
        let args = arr[i].split(" -> ");
        objs[args[0]] = {};
        objs[args[0]].name = args[0];
        objs[args[0]].age = args[1];
        objs[args[0]].grade = args[2];
    }

    for(let obj in objs){
        console.log("Name: " + objs[obj].name);
        console.log("Age: " + objs[obj].age);
        console.log("Grade: " + objs[obj].grade);
    }
}

solution([
    "Pesho -> 13 -> 6.00",
    "Ivan -> 12 -> 5.57",
    "Toni -> 13 -> 4.90",
]);