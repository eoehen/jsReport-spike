function now() {
    return new Date().toLocaleDateString()
}

function nowPlus20Days() {
    var date = new Date()
    date.setDate(date.getDate() + 20);
    return date.toLocaleDateString();
}

function total(items) {
    var sum = 0
    items.forEach(function (i) {
        console.log('Calculating item ' + i.name + '; you should see this message in debug run')
        sum += i.price
    })
    return sum
}


// Encoding ????

//const iconv = require('iconv-lite');
//function afterRender(req, res) {
//    res.content = Buffer.from(iconv.encode(res.content.toString(), 'win1252'), 'binary')
//}
