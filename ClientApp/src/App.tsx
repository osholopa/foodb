import { ThemeProvider, useMediaQuery } from "@mui/material";
import { Route, Routes } from "react-router-dom";
import Login from "pages/Login";
import AppBar from "components/AppBar";
import RecipeList from "pages/RecipeList";
import Recipe from "pages/Recipe";
import SignUp from "pages/SignUp";
import { lightTheme, darkTheme } from "themes";



function App() {

  const isLightMode = useMediaQuery("(prefers-color-scheme: light)");
  const theme = isLightMode ? lightTheme : darkTheme;

  return (
    <ThemeProvider theme={theme}>
      <div className="App">
        <AppBar />
        <Routes>
          <Route path="/" element={<RecipeList />} />
          <Route path="/recipes" element={<RecipeList />} />
          <Route path="/recipe/:id" element={<Recipe />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<SignUp />} />
        </Routes>
      </div>
    </ThemeProvider>
  );
}

export default App;
