import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import BarChartIcon from '@material-ui/icons/BarChart';
import DashboardIcon from '@material-ui/icons/Dashboard';
import React from 'react';
import * as S from './styled';
import { Link } from 'react-router-dom';

const Menu = ({ }) => {
    return (
        <S.Container>
            <S.Head />
            <S.Separator />
            <S.MenuListContainer>
                <Link to="/">
                    <ListItem button>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="Modify Settings" />
                    </ListItem>
                </Link>
                <Link to="/history">
                    <ListItem button>
                        <ListItemIcon>
                            <BarChartIcon />
                        </ListItemIcon>
                        <ListItemText primary="History" />
                    </ListItem>
                </Link>
            </S.MenuListContainer>
        </S.Container>
    );
};

export default Menu;
