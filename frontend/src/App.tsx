import { Route, Routes } from "react-router-dom"

function App() {
  return (
    <>
      <Routes>
        <Route path="/" /*element={Landing}*//>
        <Route path="/register" /*element={AuthPage}*//>
        <Route path="/login" /*element={AuthPage}*//>
        <Route path="/dashboard" /*element={Dashboard}*//>
        <Route path="/admin" /*element={AdminPanel}*//>
      </Routes>
    </>
  )
}

export default App
