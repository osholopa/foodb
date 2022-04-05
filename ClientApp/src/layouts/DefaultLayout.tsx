import { Box } from "@mui/material";

export default function DefaultLayout({ children }: any) {
    return (
        <Box sx={{mx: 4, my: 4}}>
            {children}
        </Box>
    )
}