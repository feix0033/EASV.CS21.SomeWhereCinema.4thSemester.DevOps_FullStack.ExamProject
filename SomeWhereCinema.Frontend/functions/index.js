const admin = require("firebase-admin");
const functions = require('firebase-functions');
const cors = require('cors');
const app = require('express')();

app.use(cors());
admin.initializeApp();

app.post("/order/creatOrder",
  (res,req) =>{
    let order = res.body;
    functions.logger.log(order);
    admin.firestore()
      .collection(order.userId)
      .doc(order.orderId)
      .set({orderHistory:order});
});

exports.api = functions.https.onRequest(app);


// exports.authTriggeredFunction = functions.auth
//   .user().onCreate(
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
