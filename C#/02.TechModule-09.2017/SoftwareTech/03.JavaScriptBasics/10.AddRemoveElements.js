function solution(arr){
    let numArray = [];
    for(let i = 0; i < arr.length; i++){
        let cmd = arr[i].split(" ")[0];
        let index = arr[i].split(" ")[1];

        if(cmd === "add")
        {
            numArray.push(index);
            numArray.length;
        }
        else if(cmd === "remove"){
            if(numArray[index] != undefined){
                numArray.splice(index, 1);
            }
        }
    }

    for (const prop in numArray) {
        console.log(numArray[prop]);
    }
}

/*solution([
    "add 3",
    "add 5",
    "add 7",
]);

console.log();
solution([
    "add 3",
    "add 5",
    "remove 1",
    "add 2",
]);*/

console.log();
solution([
    "add 3",
    "add 5",
    "remove 2",
    "remove 0",
    "add 7",
])