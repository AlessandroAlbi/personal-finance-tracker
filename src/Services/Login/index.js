import express from "express";
import cors from "cors";
const app = express();

app.use(cors());

app.use("/login", (req, res) => {
  res.send({
    token: "test123",
  });
});


app.listen(8081, () => console.log('API is running on http://localhost:8081/login'));