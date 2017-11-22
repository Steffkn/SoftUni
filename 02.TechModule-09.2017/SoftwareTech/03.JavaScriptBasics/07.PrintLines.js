function solution(arr){
    for(let i = 0; i< arr.length-1; i++){
        if(arr[i] === "Stop")
        {
            break;
        }
        console.log(arr[i]);
    }
}
