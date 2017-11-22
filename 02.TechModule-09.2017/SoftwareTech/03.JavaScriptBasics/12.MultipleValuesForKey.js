function solution(arr){
    let dict = {};

    for(let i = 0; i < arr.length; i++){
        var key = arr[i].split(" ")[0];
        let value = arr[i].split(" ")[1];

        if(value === undefined) {
            break;
        }

        if(dict[key] !== undefined){
            dict[key].push(value);
        }
        else {
            dict[key] = [value];
        }
    }

    if(key in dict){
        for(let val in dict[key]){
            console.log(dict[key][val]);
        }
    }
    else{
        console.log("None");
    }
}

solution([
    "key value",
    "key eulav",
    "test tsete",
    "key"
]);