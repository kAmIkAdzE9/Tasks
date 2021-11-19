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
    }
]

let hasColor = c => r => r.color == c;
let isRed = r => hasColor('red')(r);
let isBlack = r => hasColor('black')(r);
let isSquare = r => r.width == r.height;
let calcArea = r => r.width * r.height;
let calcPerimeter = r => 2 * (r.width + r.height);
let add = (a, b) => a + b;
let max = (a, b) => Math.max(a, b);
let filter = condition => list => list.filter(condition);
let map = fn => list => list.map(fn);
let reduce = (fn, value) => list => list.reduce(fn, value);
let sum = reduce(add, 0);
let flow = functions => data => functions.reduce((accum, func) => func(accum), data);
let combine = functions => data => functions.reverse().reduce((accum, func) => func(accum), data);
// function flow(functions, data) {
//     if(functions.length == 0) {
//         return data;
//     }
//     let new_list = functions[0](data);
//     let new_functions = functions;
//     new_functions.shift();
//     return flow(new_functions, new_list);
// }

let or = (a, b) => a || b;
let and = (a, b) => a && b;

let combinedCond = (conditions, predicate) => {
    if(conditions.length == 0) {
        return;
    }
    let result = conditions[0];
    for(let cond of conditions) {
        result = predicate(cond, result);
    }
    return result;
}

let any = conditions => combinedCond(conditions, or);
let all = conditions => combinedCond(conditions, and);


let maxAreaOfBlackSquares = flow([
    filter(all([isBlack, isSquare])), 
    map(calcArea), 
    reduce(max, 0)]
)
(rectangles);

let totalPerimeterOfRedRectangles = combine([
    sum,
    map(calcPerimeter), 
    filter(isRed)]
)
(rectangles);

//logging
console.log(rectangles);

rectangles.forEach(r => {
    console.log(`Is red: ${isRed(r)}; Is black: ${isBlack(r)}`);
});

console.log('Max area of black squares is ' + maxAreaOfBlackSquares);
console.log('Total perimeter of red rectangles is ' + totalPerimeterOfRedRectangles);