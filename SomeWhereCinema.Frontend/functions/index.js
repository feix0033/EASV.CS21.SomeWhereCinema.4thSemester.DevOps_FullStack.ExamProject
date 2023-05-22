const admin = require("firebase-admin");
const cors = require('cors');
const functions = require('firebase-functions');
const app = require('express')().use(cors());

let db = [
  {name: "John Wick", price: 120},
  {name: "John Wick II", price: 120}
];

// admin.initializeApp({projectId: 'SomeWhereCinema'});

app.get('/movie/GetAllMovie',
  (req, res) =>
  {
    functions.logger.log(req.body);
    return res.json(db);
  });

app.post('/movie/CreateMovie',
  (req, res) =>
  {
    functions.logger.log(req.body);
    db.push({"name":req.body.name,"price":req.body.price});
    return res.json([{"name":req.body.name,"price":req.body.price}]);
    // db.push(req);
  });

app.delete('/Movie/delete',
  (req, res) =>
  {
    functions.logger.log(req.body.name);
    db = db.splice(db.indexOf(req.body),1);
    return res.json(db);
  }
);


exports.api = functions.https.onRequest(app);


//
// exports.authTriggeredFunction = functions.auth
//   .user.onCreate(
//   (user,context) => {
//     admin
//       .firestore()
//       .collection('user')
//       .doc(user.uid)
//       .set({name:user.displayName});
//   }
// )
//
// exports.firestoreTriggeredFunction = functions.firestore.document('user/{document}')
//   .onCreate((snapshot,context) => {
//     functions.logger.log("hello world");
//   });
