const rectangles = [
    {
        "PointTopLeft": { "x": 0, "y": 0 },
        "width": 4,
        "height": 3,
        "color": 'red'
    },

    {
        "PointTopLeft": { "x": 0, "y": 0 },
        "width": 2,
        "height": 1,
        "color": 'black'
    },

    {
        "PointTopLeft": { "x": 0, "y": 0 },
        "width": 7,
        "height": 5,
        "color": 'red'
    },

    {
        "PointTopLeft": { "x": 0, "y": 0 },
        "width": 4,
        "height": 4,
        "color": 'black'
    },

    {
        "PointTopLeft": { "x": 0, "y": 0 },
        "width": 6,
        "height": 6,
        "color": 'black'
    },

    {
        "PointTopLeft": { "x": 0, "y": 0 },
        "width": 7,
        "height": 7,
        "color": 'red'
    },

    {
        "PointTopLeft": { "x": 0, "y": 0 },
        "width": 108,
        "height": 8,
        "color": 'black'
    },

    {
        "PointTopLeft": { "x": 0, "y": 0 },
        "width": 20,
        "height": 20,
        "color": 'green'
    }
]

let hasColor = c => r => r.color == c;
let isRed = hasColor('red');
let isBlack = hasColor('black');
let isSquare = r => r.width == r.height;
let calcArea = r => r.width * r.height;
let calcPerimeter = r => 2 * (r.width + r.height);
let add = (a, b) => a + b;
let max = (a, b) => Math.max(a, b);
let filter = predicate => list => list.filter(predicate);
let map = fn => list => list.map(fn);
let reduce = (reducer, initVal) => list => list.reduce(reducer, initVal);
let sum = reduce(add, 0);
let maxFromList = reduce(max, 0);
let flow = functions => data => functions.reduce((accum, func) => func(accum), data);
let combine = (...functions) => flow(functions.reverse())
// function flow(functions, data) {
//     if(functions.length == 0) {
//         return data;
//     }
//     let new_list = functions[0](data);
//     let new_functions = functions;
//     new_functions.shift();
//     return flow(new_functions, new_list);
// }

let or = (a, b) => value => a(value) || b(value); 
let and = (a, b) => value => a(value) && b(value);
let any = (...functions) => functions.reduce(or);
let all = (...functions) => functions.reduce(and);

// let or = a => b => a || b;
// let and = a => b => a && b;

// let combinedPredicate = functions => predicate => data => {
//     if(functions.length == 0) {
//         return () => {return true};
//     }
//     let result = functions[0](data);
//     for(let func of functions) {
//         result = predicate(result)(func(data));
//     }
//     return result;
// }

// let any = functions  => combinedPredicate(functions)(or);
// let all = functions  => combinedPredicate(functions)(and);

//must be 36
let maxAreaOfBlackSquares = flow([
    filter(all(isBlack, isSquare)),
    map(calcArea),
    maxFromList])
(rectangles);

let maxAreaOfRedSquares = combine(
    maxFromList,
    map(calcArea),
    filter(all(isSquare, isRed))
)
(rectangles);

//must be 66
let totalPerimeterOfRedRectangles = combine(
    sum,
    map(calcPerimeter), 
    filter(isRed)
)
(rectangles);

//logging
//console.log(rectangles);
console.log('Max area of black squares is ' + maxAreaOfBlackSquares);
console.log('Total perimeter of red rectangles is ' + totalPerimeterOfRedRectangles);
console.log('Max area of red squares is ' + maxAreaOfRedSquares);