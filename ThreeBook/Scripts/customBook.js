
const promise1 = Promise.resolve(3);
const promise2 = 42;
const promise3 = new Promise((resolve, reject) => {
    setTimeout(resolve, 2000, '100');
});
console.log("========" );
Promise.all([promise1, promise2, promise3]).then((values) => {
    console.log("values =", values);
    console.log("GGGGGGGGG = ", (values[2]+999));
}); 
console.log("========");