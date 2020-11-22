import { withStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";

const WhiteTextTypography = withStyles({
    root: {
        color: "white"
    }
})(Typography);

export default WhiteTextTypography;