function solution(arr){
    let numArray = {};
    for(let i = 0; i < arr.length; i++){
        let key = arr[i].split(" ")[0];
        let value = arr[i].split(" ")[1];
        if(value != undefined){
            numArray[key]= value;
        }
        else{
            if(numArray[key] != undefined){
                return numArray[key];
            }
            else{
                return "None";
            }
        }
    }
}

let result = solution([
    "key value",
    "key eulav",
    "test tsete",
    "key"
]);

console.log(result);
