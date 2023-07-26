
function GetFirstBook() {

    console.log("============= 00 = " );
    let result;
    let getKol = async () => {
       
        const response = await fetch("/Home/FirstBook")
            .then((response) => {
                return response.json();
            }).then((data) => {
                console.log("book = ", data);
                result = data;
                return result;
            }).catch(err => console.log("ERROR = ", err));
        
    }
    getKol();
   
    var kol = [3, 5, 7, 9];
    var t = kol.find(a => a == 7);
    var tt = [...kol, 999];
    var ttt = kol.push(666);
    
    console.log("00001 = ", tt);
    console.log("00002 = ", ttt);
    
    
}
function GetLastBook() {
    console.log("---------00    ");
    const req = fetch('/Home/LastBook', { method: 'GET' });
    req.then(res => { 
        return res.json();
        console.log("00 res = ", result)
        console.log("01 res = ", result.data)
       // console.log("02 res = ", res.text())
      

    }).then(r => { console.log("===", r); });

    console.log("03  s = " )
   //let response =   await (fetch('/Home/LastBook', { method: 'GET' }));
   // let response = await fetch('/Home/LastBook' );
  //  var data =  await response.json();
   
}
async function fetchMoviesJSON() {
    const response = await fetch('/Home/LastBook', { method: 'GET' });
    const movies = await response.json();
    console.log("0 data = ", movies);

    var k = 5;
    var kol =()=>{
        return new Promise((resolve, reject) => {
            if (k == 0) {
                resolve(7);
            } else {
                reject(5);
            }
        });
    }
   // var ttt = kol;
    kol().then(i => { console.log("ii =", i) }).catch(u => { console.log("uuu =", u) });

    return movies;
}



document.cookie = "deletename=kol_; expires=Thu, 18 Dec 2024 12:00:00 UTC; path=/";